//------------------------------------mainCtrlr-----------------------------//
application.controller('mainCtrlr',  mainCtrlr);
function mainCtrlr($scope) {
    $scope.load = function () {
        $scope.imageSource = imageSource;
        $scope.videoSource = videoSource;
        $scope.packageImageSource = packageImageSource;
        
    };


    $scope.show_time = function () {

        d = new Date();
        H = d.getHours(); H = (H < 10) ? "0" + H : H;
        i = d.getMinutes(); i = (i < 10) ? "0" + i : i;
        s = d.getSeconds(); s = (s < 10) ? "0" + s : s;
        setTimeout(function () {
            document.getElementById('show_time_1').innerHTML = H + ":" + i;
        }, 10);
        setTimeout(function () { $scope.show_time() }, 1000);/* 1 sec */
    };
    $scope.showDate = function () {

        var _date = showdate();
        setTimeout(function () {
            document.getElementById('date').innerHTML = _date;
        }, 10);
        //$(".txtDate").text(_date);
    }
    $scope.weatherFun = function () {
        $.simpleWeather({
            location: 'Tehran, IR',
            woeid: '',
            unit: 'c',
            success: function (weather) {
                html = '<span class="wi"><i class="wi-' + weather.code + '"></i></span><span class="cw">' + weather.temp + '</span><span class="cc">' + '&deg;' + weather.units.temp + '</span>';

                $("#weather").html(html);
            },
            error: function (error) {
                $("#weather").html('<p>' + error + '</p>');
            }
        });
    };
    $scope.setPosition = function (itemList, positionType) {

        switch (positionType) {
            case 1: {//Image
                $scope.sliderImageList = itemList;
                break;
            }
            case 2: {//Video
                setTimeout(function () {
                    $scope.runPlayer(itemList);
                }, 2000)
                break;
            }
            case 3: {//Text
                $scope.sliderTextList = itemList;
                break;
            }
            case 4: {//weather

                $scope.weatherFun();
                break;
            }
            case 5: {//time

                $scope.show_time();
                $scope.showDate();
                break;
            }
            case 0: {//none
                break;
            }
            default: {
                break;
            }
        };

        setTimeout(function () {
            $scope.slider($scope.sliderImageList);
        }, 1000);
    };


    $scope.load();
};
//------------------------------------showContentCtrlr-----------------------------//
application.controller('showContentCtrlr', showContentCtrlr);
function showContentCtrlr($scope, httpRequest) {
    showContentCtrlr($scope, httpRequest);
};

//------------------------------------editContentCtrlr-----------------------------//
application.controller('editContentCtrlr', editContentCtrlr);
function editContentCtrlr($scope, httpRequest) {
    editContentCtrlr($scope, httpRequest);
};
//------------------------------------editContentSelectorCtrlr-----------------------------//
application.controller('editContentSelectorCtrlr', editContentSelectorCtrlr);
function editContentSelectorCtrlr($scope, httpRequest) {
    editContentSelectorCtrlr($scope, httpRequest);
};
//------------------------------------editContentTempCtrlr_1-----------------------------//
application.controller('editContentTempCtrlr_1', editContentTempCtrlr_1);
function editContentTempCtrlr_1($scope) {
    editContentTempCtrlr_1($scope);
};
