function adsCtrlr($scope, $compile, httpRequest, UploadFile) {
    $scope.fileread;
    $scope.items = [];
    $scope.adsInfo = [];

    $scope.adsIemList = [];

    var obj = new Object();


    $scope.load = function () {
    };
    $scope.load();
    var getImageTemplate = function (file, fileName) {

        return '<div class="col" id="' + fileName + '.jpg' + '"><img src="' + file + '" style="height:36px; width:40px;" /><a class="packageItemBtnDelete" ng-click="delFile(\'' + fileName + '.jpg' + '\')"><span class="icon" data-icon="&#xe0da;"></span></a></div>'
    }
    var getVideoTemplate = function (file, fileName) {
        debugger
        return '<div class="col" id="' + fileName + '.mp4' + '"><video style="height:36px; width:40px;" ><source src="' + file + '"></video><a class="packageItemBtnDelete" ng-click="delFile(\'' + fileName + '.mp4' + '\')"><span class="icon" data-icon="&#xe0da;"></span></a></div>'
    }
    var getTextTemplate = function (text) {
        

        var template = '<div class="row itemSpace _textTemplate showText">'
            + '<div class="col11" id="' + text + '" >'
            + '<input class="formInputDefault" type="text"  value=' + text + '>'
            + '</div>' 
            +'<div></div>'
            + '<div  class="col1 itemSpace"> <a class="btnSmallOk" ng-click="delText(' + "'" + text + "'" + ')"><span class="icon" data-icon="&#xe0da;"></span></a> </div>'
            + '</div>';

        return template;
    }
    //Upload Image
    $(myFile).bind("change", function (changeEvent) {

        $scope.$apply(function () {
            var adsObj = new Object();
            $scope.fileread = changeEvent.target.files[0];
            var fileReader = new FileReader();
            fileReader.onload = function (e) {
                var fileName = guid();

                var el = $compile(getImageTemplate(e.target.result, fileName))($scope);
                $("#fileContainet").append(el);
                UploadFile.upload(service_uploadFile, 'myFile', '.jpg', fileName, function (data, fileName) {
                    var fileNameObj = new Object();
                    fileNameObj.file_name = fileName;
                    $scope.adsIemList.push(fileNameObj);
                });
            }
            fileReader.readAsDataURL($scope.fileread);
        });
    });

    //Upload Video
    $(myVideo).bind("change", function (changeEvent) {
        $scope.$apply(function () {
            var adsObj = new Object();
            $scope.fileread = changeEvent.target.files[0];

            var fileReader = new FileReader();
            fileReader.onload = function (e) {
                var fileName = guid();
                var el = $compile(getVideoTemplate(e.target.result, fileName))($scope);
                $("#fileVideoContainet").append(el);
                UploadFile.upload(service_uploadFile, 'myVideo', '.mp4', fileName, function (data, fileName) {
                    var fileNameObj = new Object();
                    fileNameObj.file_name = fileName;
                    $scope.adsIemList.push(fileNameObj);
                });
            }
            fileReader.readAsDataURL($scope.fileread);
        });
    });

    $scope.selectItem = function (result) {
        $scope.adsIemList = [];
        $("#fileContainet").html('');
        $("#fileVideoContainet").html('');
        $("#showText").html('');
        $('._textTemplate').each(function () {

            $(this).html("");
        })
        angular.element("input[type='file']").val(null);
        $scope.adsInfo.type = result;


    };


    $scope.saveAds = function () {
        $scope.adsInfo.itemList = $scope.adsIemList;
        if ($scope.adsInfo.itemList.length > 0) {

            httpRequest.post(service_addAds, $scope.adsInfo, function (data) {
                alert('اطلاعات با موفقیت درج شد.');
                $scope.adsInfo = [];
                $scope.adsIemList = [];
                $("#fileContainet").html('');
                $("#fileVideoContainet").html('');
                $(".showText").each(function () { $(this).html(''); });

            }, function () { alert('خطا در درج اطلاعات.'); });


        }
    };

    $scope.cancelAds = function () {
        $scope.adsInfo = [];
        $scope.adsIemList = [];
        $("#fileContainet").html('');
        $("#fileVideoContainet").html('');
        $(".showText").each(function () { $(this).html(''); });
    };


    $scope.addText = function (text) {

        var fileNameObj = new Object();
        fileNameObj.title = text;
        $scope.adsIemList.push(fileNameObj);
        $scope.adsInfo.adItemTitle = '';
        var t = $compile(getTextTemplate(text))($scope);
        $("#_showText").after(t);
    }

    $scope.delFile = function (fileName) {
        debugger
        //Delete From Hard
        var obj = new Object();
        obj.fileName = fileName;
        httpRequest.post(service_deladsFile, obj, function (data) {

        }, function () { alert('خطا در حذف فایل.'); });
        debugger
        //Delete Html
        $('div[id$="' + fileName + '"]').html('');

        //Delete From  $scope.adsInfo
        if ($scope.adsIemList.length > 0) {
            angular.forEach($scope.adsIemList, function (value, key) {
                if (value.file_name + ".jpg" == fileName) {
                    debugger
                    var index = $scope.adsIemList.indexOf(value);
                    $scope.adsIemList.splice(index, 1);
                }
            });
        }


    }
    $scope.delText = function (text) {
        debugger
        //Delete Html
        $('div[id$="' + text + '"]').html('');

        //Delete From  $scope.adsInfo
        if ($scope.adsIemList.length > 0) {
            angular.forEach($scope.adsIemList, function (value, key) {
                if (value.title == text) {
                    var index = $scope.adsIemList.indexOf(value);
                    $scope.adsIemList.splice(index, 1);
                }
            });
        }

    };
}