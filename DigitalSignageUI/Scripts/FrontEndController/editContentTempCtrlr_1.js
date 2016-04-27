function editContentTempCtrlr_1($scope, $rootScope) {
    $scope.load = function () {
    };
    $scope.load();

    $scope.btnTVCAEditDis = function (position, btnMode) {
       //   alert(position)
        if (btnMode == 'text') {
            switch (position) {
                case 1:
                case 2:
                case 3:
                case 5:
                    {
                        return "btnTVCAEditDis";
                        break;
                    }

                default:
                    return "btnTVCAEdit";
            }

        }
        else if (btnMode == 'tv' || btnMode == 'video' || btnMode == 'slider') {
            switch (position) {
                case 1:
                case 2:
                case 3:
                case 5:
                    {
                        return "btnTVCAEdit";
                        break;
                    }

                default:
                    return "btnTVCAEditDis";
            }
        }
        else if (btnMode == 'widget') {
            switch (position) {
                case 1:
                case 2:
                case 3:
                    {
                        return "btnTVCAEdit";
                        break;
                    }

                default:
                    return "btnTVCAEditDis";
            }
        }

    };


    $scope.WeatherWidget = function (that , wPosi) {
        if($scope.btnTVCAEditDis(wPosi , 'widget') == 'btnTVCAEdit'){
            $rootScope.$emit("loadWidgetEvt", {});
            $(that.target).attr('href', '#WeatherWidget_' + wPosi);
        }
    };

}
