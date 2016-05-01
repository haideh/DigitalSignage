
function adsCtrlr($scope, $compile, httpRequest, UploadFile) {
    $scope.fileread;
    $scope.items = [];
    $scope.adsInfo = [];

    $scope.adsIemList = [];

    var obj = new Object();


    $scope.load = function () {
    };
    $scope.load();
    var getImageTemplate = function (file) {
        return '<img src="' + file + '" style="height:36px; width:40px;" />'
    }
    var getVideoTemplate = function (file) {
        return '<video style="height:36px; width:40px;" ><source src="' + file + '"></video>'
    }
    var getTextTemplate = function (text) {
        return '<lable style="height:36px; width:40px;" >' + text + '</lable><br/>';
    }
    //Upload Image
    $(myFile).bind("change", function (changeEvent) {
        
        $scope.$apply(function () {
            var adsObj = new Object();
            $scope.fileread = changeEvent.target.files[0];
            var fileReader = new FileReader();
            fileReader.onload = function (e) {
                var el = $compile(getImageTemplate(e.target.result))($scope);
                $("#fileContainet").append(el);
                UploadFile.upload(service_addAds2, 'myFile', '.jpg', function (data, fileName) {
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
                var el = $compile(getVideoTemplate(e.target.result))($scope);
                $("#fileVideoContainet").append(el);
                UploadFile.upload(service_uploadFile, 'myVideo', '.mp4', function (data, fileName) {
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
        angular.element("input[type='file']").val(null);
        $scope.adsInfo.type = result;


    };


    $scope.saveAds = function () {
        $scope.adsInfo.itemList = $scope.adsIemList;
        if ($scope.adsInfo.itemList.length > 0) {
            httpRequest.post(service_addAds, $scope.adsInfo, function (data) {
            });
        }

    };

    $scope.addText = function (text) {
        debugger
        var fileNameObj = new Object();
        fileNameObj.title = text;
        $scope.adsIemList.push(fileNameObj);
        $scope.adsInfo.adItemTitle = '';
        $("#showText").append(getTextTemplate(text));
    }
}