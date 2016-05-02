//var application = angular.module('application', []);


//-----------------------------------factory for select and deselect menu--------------------//
application.factory('SelectMenu', function () {

    var service = {};
    service.packageList = 'select',
    service.addNewPackage = '',
    service.editPackage = '',
    service.logOut = '';
    
    service.resetAll = function () {
        service.packageList = 'select',
        service.addNewPackage = '',
        service.editPackage = '',
        service.logOut = '';
    };
    service.selectPackageList = function () {
        service.resetAll();
    };
    service.selectAddNewPackage = function () {
        service.packageList = '',
        service.addNewPackage = 'select',
        service.editPackage = '',
        service.logOut = '';
    };
    service.selectEditPackage = function () {
        
        service.packageList = '',
        service.addNewPackage = '',
        service.editPackage = 'select',
        service.logOut = '';
    };
    service.selectLogOut = function () {
        service.packageList = '',
        service.addNewPackage = '',
        service.editPackage = '',
        service.logOut = 'select';
    };
    return service;
});

//-----------------------------------factory for hide and show menubar--------------------//
application.factory('MenuBar', function () {
    var MenuBarStatus = false;
    return {
        getMenuBarStatus: function () { return MenuBarStatus; },
        setMenuBarStatus: function (newStatus) { MenuBarStatus = newStatus; }
    };
});

//-----------------------------------factory for hide and show menubar--------------------//
//application.factory('MenuBar', function () {
//    var MenuBarStatus = false;
//    return {
//        MenuBarStatus: function () { return MenuBarStatus; },
//        setMenuBarStatus: function (newStatus) { MenuBarStatus = newStatus; }
//    };
//});

//-----------------------------------factory for hide and show loader--------------------//
//application.factory('Loader', function () {
//    var Loading = false;
//    return {
//        getLoader: function () { return Loading; },
//        setLoader: function (loadingStatus) {
//            Loading = loadingStatus;
//        }
//    };
//});



//---------------------------------------- change Background ------------------------------------------//

//application.factory('changeBackGround', function () {
//    //	if (! sessionStorage.getItem("backGroundStyle")){
//    var myStyle = { 'background-image': 'url(./assets/images/bkDefault.jpg)' };
//    //	}
//    var service = {};

//    service.setBackground = function (imgCode, BgFlag) {
//        $('body').removeClass('bkWrap');
//        localStorage.setItem("cssStyleFlag", false);

//        switch (imgCode) {
//            case '0':
//                myStyle = { 'background-image': 'url(./assets/images/bkDefault.jpg)' };
//                break;

//            case '1':
//                myStyle = { 'background-image': 'url(./assets/images/bkSetABk.jpg)' };
//                break;

//            case '2':
//                myStyle = { 'background-image': 'url(./assets/images/bkSetBBk.jpg)' };
//                break;

//            case '3':
//                myStyle = { 'background-image': 'url(./assets/images/bkSetCBk.jpg)' };
//                break;

//            case 'gray':
//                myStyle = { background: '#D7D7D7' };
//                break;

//            case 'blue':
//                myStyle = { background: '#C5E3EC' };
//                break;

//            case 'pink':
//                myStyle = { background: '#E6DCE5' };
//                break;

//            case 'green':
//                myStyle = { background: '#D4E5D2' };
//                break;


//            default:
//                break;
//        }

//        localStorage.setItem("backGroundStyle", JSON.stringify(myStyle));
//        localStorage.setItem("backGroundCode", imgCode);
//        localStorage.setItem("bgFlag", BgFlag);

//    },

//	service.getBGStyle = function () {
//	    return myStyle;
//	};


//    return service;
//});



//---------------------------------------- change css ----------------------------------------------//

//application.factory('changeBackGroundCSS', function () {

//    if (localStorage.getItem("cssStyle")) {
//        var href = localStorage.getItem("cssStyle");
//    }
//    else
//        href = "./assets/css/setA.css";

//    var service = {};
//    service.setBackgroundCSS = function (type) {

//        $('body').addClass('bkWrap');
//        var Linkhref = document.getElementById("mainLink");
//        localStorage.setItem("cssStyleFlag", true);
//        localStorage.setItem("csstype", type);
//        switch (type) {
//            case "setA":
//                Linkhref.href = "./assets/css/setA.css";
//                localStorage.setItem("cssStyle", "./assets/css/setA.css");
//                break;

//            case "setB":
//                Linkhref.href = "./assets/css/setB.css";
//                localStorage.setItem("cssStyle", "./assets/css/setB.css");
//                break;

//            case "setC":
//                Linkhref.href = "./assets/css/setC.css";
//                localStorage.setItem("cssStyle", "./assets/css/setC.css");
//                break;

//            default:
//                break;
//        }

//    },

//	service.getBackgroundCSS = function () {

//	    localStorage.setItem("cssStyle", href);
//	    return href;
//	};

//    return service;
//});

//---------------------------------------- End change css ------------------------------------------//


//-----------------------------------------paging--------------------------------------//
//application.factory('paging', function () {
//    return {
//        getPaging: function (data, pageSize, pagingUl) { getPaging(data, pageSize, pagingUl); },
//        previous: function () { previous(); },
//        next: function () { next(); },
//        setting: function (ulCls, divCls, pageNumber) {

//            $(ulCls + " li").removeClass('current');
//            $(ulCls + " li[id=" + pageNumber + "]").addClass('current');
//            $(divCls + ' #current_page').val(pageNumber);
//        }
//    };
//});