function editContentSelectorCtrlr($scope, $rootScope, httpRequest, MenuBar) {

    $scope.adsItemDetailListCreator = function (serviceName, dataObj, type) {
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
                contentObj.companyId = $scope.viewData[adsIndex].companyId;

                var contenDetailObjList = new Array();
                for (var adsitemIndex = 0; adsitemIndex < $scope.viewData[adsIndex].itemList.length; adsitemIndex++) {
                    var contenDetailObj = new Object();
                    contenDetailObj.adsItemTitle = $scope.viewData[adsIndex].itemList[adsitemIndex].title;
                    contenDetailObj.adsItemType = $scope.viewData[adsIndex].itemList[adsitemIndex].type;
                    contenDetailObj.file_name = $scope.viewData[adsIndex].itemList[adsitemIndex].file_name;

                    contenDetailObjList.push(contenDetailObj);
                }
              
                if (contentObj.type == '2') {
                   
                    if (contenDetailObjList.length > 0)
                        $scope.runPlayer(contenDetailObjList);
                }

                contentObj.itemList = contenDetailObjList;

                resultList.push(contentObj);
            }
        });

        return resultList;
    };


    $scope.liveItemDetailListCreator = function (serviceName, dataObj) {
        $scope.viewData = [];
        var resultList = new Array();

        httpRequest.post(serviceName, dataObj, function (data) {
            $scope.viewData = data.resultSet;
            for (var adsIndex = 0; adsIndex < $scope.viewData.length; adsIndex++) {
                var contentObj = new Object();
                contentObj.id = $scope.viewData[adsIndex].id;
                contentObj.live_id = $scope.viewData[adsIndex].id;
                contentObj.title = $scope.viewData[adsIndex].title;
                contentObj.type = $scope.viewData[adsIndex].type;
                contentObj.content_id = $scope.viewData[adsIndex].content_id;
                contentObj.position = $scope.viewData[adsIndex].position;
                contentObj.companyId = $scope.viewData[adsIndex].companyId;
                contentObj.url = $scope.viewData[adsIndex].url;
                contentObj.nameId = $scope.viewData[adsIndex].nameId;
                contentObj.channel = $scope.viewData[adsIndex].channel;
                contentObj.interval = $scope.viewData[adsIndex].interval;
                resultList.push(contentObj);
            }
        });

        return resultList;
    };


    $scope.loadAdsList = function () {//all Ads

        $scope.resultList = [];
        var dataObj = new Object();
        dataObj.type = $scope.type;
        dataObj.contentId = $scope.contentId;
        dataObj.position = $scope.position;

        $scope.resultList = $scope.adsItemDetailListCreator(service_loadAdsItemListWithType, dataObj, 'ads');

    };
    $scope.loadContentAdsList = function () {//all ads content

        $scope.resultAdsContentList = [];
        var dataObj = new Object();
        dataObj.type = $scope.type;
        dataObj.contentId = $scope.contentId;
        dataObj.position = $scope.position;

        $scope.resultAdsContentList = $scope.adsItemDetailListCreator(service_loadContentAdsListWithPoition, dataObj, 'content');
    };


    $scope.loadLiveVideoList = function () {//all Lives

        $scope.liveResultList = [];
        var dataObj = new Object();

        dataObj.contentId = $scope.contentId;
        dataObj.position = $scope.position;

        $scope.liveResultList = $scope.liveItemDetailListCreator(service_loadContentLiveVedio, dataObj);

    };
    $scope.loadContentLiveVideoList = function () {//all Lives content

        $scope.liveResultAdsContentList = [];
        var dataObj = new Object();

        dataObj.contentId = $scope.contentId;
        dataObj.position = $scope.position;

        $scope.liveResultAdsContentList = $scope.liveItemDetailListCreator(service_loadLiveVedioContentWithPosition, dataObj);
    };


    $scope.selectWidget = function (packageInfo, mode) {

        //switch (mode) {
        //    case 'timeMode': {
        //        $scope.timeSelect = 'select';
        //        $scope.weatherSelect = '';

        //        break;
        //    }
        //    case 'weatherMode': {
        //        $scope.timeSelect = '';
        //        $scope.weatherSelect = 'select';
        //        break;
        //    }
        //    default: {
        //        break;
        //    }

        //}
        $scope.selectedWidgetPackage = packageInfo;
    };


    $scope.saveWidget = function (packageInfo) {

         
        var obj = new Object();
        obj.position = $(".positionInp").val();
        obj.content_id = $(".contentIdInp").val();

        obj.adsItemList = new Array();
        obj.adsItemList.push(packageInfo);


        httpRequest.post(service_editContentAds, obj, function (data) {
        });
        location.href = "/Edit/EditContent?contentId=" + obj.content_id;

    };

    $rootScope.$on("loadWidgetEvt", function (event, args) {
        $scope.loadWidgetInfo();
    });
    $scope.loadWidgetInfo = function () {

        $scope.viewWidgtData = [];
        $scope.resultWidgetList = [];
        var resultList = new Array();

        httpRequest.post(service_loadWidgetAdsItemListWithType, "", function (data) {

            $scope.viewWidgtData = data.resultSet;

            for (var adsIndex = 0; adsIndex < $scope.viewWidgtData.length; adsIndex++) {
                var contentObj = new Object();
                contentObj.id = $scope.viewWidgtData[adsIndex].id;
                contentObj.max_minutes = $scope.viewWidgtData[adsIndex].max_minutes;
                contentObj.title = $scope.viewWidgtData[adsIndex].title;
                contentObj.type = $scope.viewWidgtData[adsIndex].type;
                contentObj.shuffle = $scope.viewWidgtData[adsIndex].shuffle;
                contentObj.interval = $scope.viewWidgtData[adsIndex].interval;
                contentObj.companyId = $scope.viewWidgtData[adsIndex].companyId;

                var contenDetailObjList = new Array();
                for (var adsitemIndex = 0; adsitemIndex < $scope.viewWidgtData[adsIndex].itemList.length; adsitemIndex++) {
                    var contenDetailObj = new Object();
                    contenDetailObj.adsItemTitle = $scope.viewWidgtData[adsIndex].itemList[adsitemIndex].title;
                    contenDetailObj.adsItemType = $scope.viewWidgtData[adsIndex].itemList[adsitemIndex].type;
                    contenDetailObj.file_name = $scope.viewWidgtData[adsIndex].itemList[adsitemIndex].file_name;
                    contenDetailObjList.push(contenDetailObj);
                }
                contentObj.itemList = contenDetailObjList;
                resultList.push(contentObj);
            }
        });
        $scope.resultWidgetList = resultList

    };

    //End Widget


    $scope.selectPackageInf = function (packageInf) {
        $scope.selectedPackage = packageInf;
    };
    $scope.clearSelectPackageInf = function () {
        $scope.selectedPackage = [];
    };

    $scope.addOrRemAdsInList = function (selectedAds, mode) {

        switch (mode) {
            case 'add': {
                $scope.resultAdsContentList.push(selectedAds);
                var index = $scope.resultList.indexOf(selectedAds);
                $scope.resultList.splice(index, 1);
                break;
            }
            case 'remove': {

                angular.forEach($scope.adsList, function (value, key) {
                    if (value.id == selectedAds.id)
                        selectedAds.interval = value.interval;
                });

                $scope.resultList.push(selectedAds);
                var index = $scope.resultAdsContentList.indexOf(selectedAds);
                $scope.resultAdsContentList.splice(index, 1);


                //$(".panelToggle").css("display", "none");
                break;
            }
        }
    };


    $scope.addOrRemAdsInLiveList = function (selectedAds, mode) {

        switch (mode) {
            case 'add': {
                $scope.liveResultAdsContentList.push(selectedAds);
                var index = $scope.liveResultList.indexOf(selectedAds);
                $scope.liveResultList.splice(index, 1);
                break;
            }
            case 'remove': {

                angular.forEach($scope.adsList, function (value, key) {
                    if (value.id == selectedAds.id)
                        selectedAds.interval = value.interval;
                });

                $scope.liveResultList.push(selectedAds);
                var index = $scope.liveResultAdsContentList.indexOf(selectedAds);
                $scope.liveResultAdsContentList.splice(index, 1);


                //$(".panelToggle").css("display", "none");
                break;
            }
        }
    };

    $scope.showAdsInf = function () {
        // $(".panelToggle").css("display", "block");
    }

    $scope.editPackageTime = function () {
        var index = $scope.resultAdsContentList.indexOf($scope.selectedPackage);
        $scope.resultAdsContentList[index].interval = $scope.selectedPackage.interval;
        $scope.clearSelectPackageInf();
        //  $(".panelToggle").css("display", "none");
    }

    $scope.saveAdsItemPackage = function (type) {
        var obj = new Object();

        obj.position = $(".positionInp").val();
        obj.content_id = $(".contentIdInp").val();
        obj.interval = $scope.selectedPackage.interval;
        obj.adsItemList = new Array();
        
        if (type == 'lives') {
            obj.type = 1;
            obj.adsItemList = $scope.liveResultAdsContentList;
        }
        else {
            obj.type = 0;
            obj.adsItemList = $scope.resultAdsContentList;
        }
        httpRequest.post(service_editContentAds, obj, function (data) {
        });
        location.href = "/Edit/EditContent?contentId=" + obj.content_id;
    }



    $scope.cancelSaveAds = function () {
        location.href = "/Edit/EditContent?contentId=" + $(".contentIdInp").val();
    }
    $scope.load = function () {

        $scope.contentId = '';
        $scope.type = '';
        $scope.position = '';
        $scope.contentId = $(".contentIdInp").val();
        $scope.type = $(".typeInp").val();
        $scope.position = $(".positionInp").val();
        $scope.selectedPackage = [];
        $scope.selectedWidgetPackage = [];
        $scope.adsList = [];
        $scope.showIntervalFlag = true;
        if (RequestQueryString("type") == "2") {
            $scope.showIntervalFlag = false;
        }
        MenuBar.setMenuBarStatus(false);

        $scope.loadAdsList();
        $scope.loadContentAdsList();

        if ($(".AdsTypeLoad").attr("data-type") == '6') {

            $scope.loadLiveVideoList();
            $scope.loadContentLiveVideoList();
        }
        $scope.loadWidgetInfo();

    }
    $scope.load();


    $scope.keyUpImageList = function () {
        sinageAutocomplte('serach-result', 'search');
    }

    $scope.runPlayer = function (itemList) {

        runPlayer(itemList);
    };
}
