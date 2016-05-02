//------------------------------------mainCtrlr-----------------------------//
application.controller('mainCtrlr', httpRequest, mainCtrlr);
function mainCtrlr($scope, httpRequest, SelectMenu) {
    $scope.load = function () {
        $scope.imageSource = imageSource;
        $scope.videoSource = videoSource;
        $scope.SelectMenu = SelectMenu;
        $scope.packageImageSource = packageImageSource;
        
        var proLocaion = ((window.location.href).split('/', 5))[4];
        switch (proLocaion) {
            case 'AdsList': {
                $scope.SelectMenu.selectPackageList();
                break;
            }
            case 'AdsManagement': {
                $scope.SelectMenu.selectAddNewPackage();
                break;
            }
            case 'EditPackage': {
                $scope.SelectMenu.selectEditPackage();
                break;
            }
            case ':LogOut': {
                $scope.SelectMenu.selectLogOut();
                break;
            }
        }
    };


    $scope.show_time = function () {

        d = new Date();
        H = d.getHours(); H = (H < 10) ? "0" + H : H;
        i = d.getMinutes(); i = (i < 10) ? "0" + i : i;
        s = d.getSeconds(); s = (s < 10) ? "0" + s : s;
        setTimeout(function () {
            angular.element('.show_time_1').html(H + ":" + i);
      //      document.getElementById('show_time_1').innerHTML = H + ":" + i;
        }, 10);
        setTimeout(function () { $scope.show_time() }, 1000);/* 1 sec */
    };
    $scope.showDate = function () {

        var _date = showdate();
        setTimeout(function () {
            angular.element('.date').html(_date);
            //document.getElementById('date').innerHTML = _date;
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
                angular.element(".weather").html(html);
               // $("div[data-Id='weather']").html(html);
            },
            error: function (error) {
                angular.element(".weather").html('<p>' + error + '</p>');
            //    $("#weather").html('<p>' + error + '</p>');
            }
        });
    };
    $scope.selectAdsMenue = function (mode) {
        switch (mode) {
            case 'packageList': {
                $scope.locationHref = '/Ads/AdsList';
                break;
            }
            case 'addNewPackage': {
                $scope.locationHref = '/Ads/AdsManagement';
                break;
            }
            case 'editPackage': {
                //$scope.locationHref = '/Ads/EditPackage';
                break;
            }
            case 'logOut': {
                //$scope.locationHref = '/Ads/LogOut';
                break;
            }
            default: {
                $scope.SelectMenu.resetAll();
                break;
            };
        }
    }
    $scope.logOutFunction = function () {
    debugger
        httpRequest.post(service_logOut, "", function (data) {

            window.location.href = data.Url;

        });
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
function editContentCtrlr($scope,$rootScope, httpRequest) {
    editContentCtrlr($scope,$rootScope, httpRequest);
};
//------------------------------------editContentSelectorCtrlr-----------------------------//
application.controller('editContentSelectorCtrlr', editContentSelectorCtrlr);
function editContentSelectorCtrlr($scope,$rootScope, httpRequest) {
    editContentSelectorCtrlr($scope, $rootScope,httpRequest);
};
//------------------------------------editContentTempCtrlr_1-----------------------------//
application.controller('editContentTempCtrlr_1', editContentTempCtrlr_1);
function editContentTempCtrlr_1($scope, $rootScope) {
    editContentTempCtrlr_1($scope, $rootScope);
};
//------------------------------------adsCtrlr-----------------------------//
application.controller('adsCtrlr', adsCtrlr);
function adsCtrlr($scope, $compile, httpRequest, UploadFile) {
    adsCtrlr($scope, $compile, httpRequest, UploadFile);
};
//------------------------------------adsListCtrlr-----------------------------//
application.controller('adsListCtrlr', adsListCtrlr);
function adsListCtrlr($scope, httpRequest) {
    adsListCtrlr($scope, httpRequest);
};
