
function adsListCtrlr($scope, httpRequest) {

    $scope.load = function () {
        $scope.resultAdsList = [];
        $scope.loadAdsList();
    };
    $scope.loadAdsList = function () {
    
 
        httpRequest.post(service_adsList, "", function (data) {
            debugger
            var viewData = new Object();
            viewData = data.resultSet;
            for (var adsIndex = 0; adsIndex < viewData.length; adsIndex++) {
                var adsObj = new Object();
                adsObj.id = viewData[adsIndex].id;
                adsObj.max_minutes = viewData[adsIndex].max_minutes;
                adsObj.title = viewData[adsIndex].title;
                adsObj.type = viewData[adsIndex].type;
                adsObj.shuffle = viewData[adsIndex].shuffle;
                adsObj.interval = viewData[adsIndex].interval;

                var adsDetailObjList = new Array();
                for (var adsitemIndex = 0; adsitemIndex < viewData[adsIndex].itemList.length; adsitemIndex++) {
                    var adsDetailObj = new Object();
                    adsDetailObj.adsItemTitle = viewData[adsIndex].itemList[adsitemIndex].title;
                    adsDetailObj.adsItemType = viewData[adsIndex].itemList[adsitemIndex].type;
                    adsDetailObj.file_name = viewData[adsIndex].itemList[adsitemIndex].file_name;
                    adsDetailObjList.push(adsDetailObj);
                }
                adsObj.itemList = adsDetailObjList;
                $scope.resultAdsList.push(adsObj);
            }
        });

    };
    $scope.load();

}