function editContentSelectorCtrlr($scope, httpRequest) {

    $scope.adsItemDetailListCreator = function (serviceName, dataObj) {
        $scope.viewData = [];
        var resultList = new Array();

        httpRequest.post(serviceName, dataObj, function (data) {

            $scope.viewData = data.resultSet;
            for (var adsIndex = 0; adsIndex < $scope.viewData.length; adsIndex++) {
                var contentObj = new Object();
                contentObj.id = $scope.viewData[adsIndex].id;
                contentObj.max_minutes = $scope.viewData[adsIndex].max_minutes;
                contentObj.title = $scope.viewData[adsIndex].title;
                contentObj.type = $scope.viewData[adsIndex].type;
                contentObj.shuffle = $scope.viewData[adsIndex].shuffle;
                contentObj.interval = $scope.viewData[adsIndex].interval;

                var contenDetailObjList = new Array();
                for (var adsitemIndex = 0; adsitemIndex < $scope.viewData[adsIndex].itemList.length; adsitemIndex++) {
                    var contenDetailObj = new Object();
                    contenDetailObj.adsItemTitle = $scope.viewData[adsIndex].itemList[adsitemIndex].title;
                    contenDetailObj.adsItemType = $scope.viewData[adsIndex].itemList[adsitemIndex].type;
                    contenDetailObj.file_name = $scope.viewData[adsIndex].itemList[adsitemIndex].file_name;
                    contenDetailObjList.push(contenDetailObj);
                }
                contentObj.itemList = contenDetailObjList;
                resultList.push(contentObj);
            }
        });
        return resultList;
    };

    $scope.loadAdsList = function () {
       
        $scope.resultList = [];
        var dataObj = new Object();
        dataObj.type = $scope.type;

        $scope.resultList =  $scope.adsItemDetailListCreator(service_loadAdsItemListWithType, dataObj);
    };


    $scope.loadContentAdsList = function () {

        $scope.resultAdsContentList = [];
        var dataObj = new Object();
        dataObj.type = $scope.type;
        dataObj.contentId = $scope.contentId;
        dataObj.position = $scope.position;

        $scope.resultAdsContentList = $scope.adsItemDetailListCreator(service_loadContentAdsListWithPoition, dataObj);
    };

    $scope.selectShuffle = function (shuffle) {
        
    };
    $scope.selectPackageInf = function (packageInf) {
        $scope.selectedPackage = packageInf;
    };
    $scope.clearSelectPackageInf = function () {
        $scope.selectedPackage = [];
    };
    $scope.load = function () {
  
        $scope.contentId = '';
        $scope.type = '';
        $scope.position = '';
        $scope.contentId = $(".contentIdInp").val();
        $scope.type = $(".typeInp").val();
        $scope.position = $(".positionInp").val();
        $scope.selectedPackage = [];
        
        $scope.loadAdsList();
        $scope.loadContentAdsList();

    }
    $scope.load();

  
    $scope.keyUpImageList = function () {
        sinageAutocomplte('serach-result', 'search');
    }
}
