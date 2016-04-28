function editContentCtrlr($scope,$rootScope, httpRequest) {
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

    $scope.deleteContentAds=function(contentId,position)
    {
        var obj = new Object();
        obj.position = position;
        obj.content_id = contentId;

        debugger
        httpRequest.post(service_deleteContentAds, obj, function (data) {
          
        });

        location.href = "/Edit/EditContent?contentId=" + contentId;
        
    }
    $scope.load = function () {
        
        $scope.timeSelect = '';
        $scope.weatherSelect = '';
        $scope.contentId = '';
        $scope.selectedWidgetPackage = [];
        $scope.imageSource = imageSource;
        var dataObj = new Object();
        dataObj.content_id = $(".contentIdInp").val();


        $scope.viewData = [];
        $scope.viewDataPosition_5 = [];
        $scope.viewDataPosition_2 = [];
        $scope.viewDataPosition_4 = [];
        $scope.viewDataPosition_1 = [];
        $scope.viewDataPosition_3 = [];

        $scope.sliderImageList = [];
        $scope.sliderTextList = [];

        $scope.Posi5 = 0;
        $scope.Posi4 = 0;
        $scope.Posi2 = 0;
        $scope.Posi1 = 0;
        $scope.Posi3 = 0;

        httpRequest.post(service_loadContentsWithAdsItemDetail, dataObj, function (data) {
            $scope.viewData = data.resultSet;
            for (var posi = 0; posi < $scope.viewData.length; posi++) {
                $scope.posi = $scope.viewData[posi].position;

                for (var img_i = 0; img_i < $scope.viewData[posi].itemList.length; img_i++) {
                    var contentObj = new Object();

                    contentObj.id = $scope.viewData[posi].id;
                    contentObj.interval = $scope.viewData[posi].interval;
                    contentObj.content_ad_id = $scope.viewData[posi].content_ad_id;
                    contentObj.title = $scope.viewData[posi].title;
                    contentObj.type = $scope.viewData[posi].type;
                    contentObj.description = $scope.viewData[posi].itemList[img_i].description;
                    contentObj.file_name = $scope.viewData[posi].itemList[img_i].file_name;

                    if ($scope.viewData[posi].position == 5) {
                        $scope.viewDataPosition_5.push(contentObj);
                        //Postion Value
                        $scope.Posi5 = $scope.viewData[posi].type;

                    }
                    if ($scope.viewData[posi].position == 2) {
                        $scope.viewDataPosition_2.push(contentObj);
                        //Postion Value
                        $scope.Posi2 = $scope.viewData[posi].type;
                    }
                    if ($scope.viewData[posi].position == 4) {
                        $scope.viewDataPosition_4.push(contentObj);
                        //Postion Value
                        $scope.Posi4 = $scope.viewData[posi].type;

                    }

                    if ($scope.viewData[posi].position == 1) {
                        $scope.viewDataPosition_1.push(contentObj);
                        //Postion Value
                        $scope.Posi1 = $scope.viewData[posi].type;

                    }

                    if ($scope.viewData[posi].position == 3) {
                        $scope.viewDataPosition_3.push(contentObj);
                        //Postion Value
                        $scope.Posi3 = $scope.viewData[posi].type;

                    }
                }
            }

            //check position type
            $scope.setPosition($scope.viewDataPosition_4, $scope.Posi4);
            $scope.setPosition($scope.viewDataPosition_2, $scope.Posi2);
            $scope.setPosition($scope.viewDataPosition_5, $scope.Posi5);
            $scope.setPosition($scope.viewDataPosition_1, $scope.Posi1);
            $scope.setPosition($scope.viewDataPosition_3, $scope.Posi3);

        });

    }

    $scope.load();

    $scope.runPlayer = function (itemList) {
        var videoArr = new Array();
        for (var iVideo = 0 ; iVideo < itemList.length ; iVideo++) {
            videoArr.push(videoSource + itemList[iVideo].file_name);
        }


        $f(".flowplayerVideo", flowPlayerSWF, {

            clip: {
                url: videoSource + itemList[0].file_name,
                scaling: "fit",
                //duration: 10,
                onBeforeFinish: function (clip) {
                    // return false on last clip
                    return clip.index < this.getPlaylist().length - 1;
                }
            },
            playlist: videoArr,
            plugins: {
                controls: { playlist: true }
            }

        });

    };

    $scope.slider = function (imageList) {
        $scope.sliderImageList = imageList;
        var transitionsArray = new Array();
        //transitionsArray.push('bars','blinds','blocks','blocks2','concentric','slide','warp','zip','bars3d','blinds3d','cube','tiles3d','turn');
        transitionsArray.push('bars', 'blinds', 'blocks', 'blocks2', 'concentric', 'slide', 'warp', 'zip', 'bars3d', 'blinds3d', 'cube', 'tiles3d', 'turn');
        var dlayArr = new Array();
        dlayArr.push(1000, 2000, 3000, 4000, 1000);
        if (!flux.browser.supportsTransitions)
            alert("Flux Slider requires a browser that supports CSS3 transitions");
        window.f = new flux.slider('.coin-slider', {
            pagination: false,
            //controls: true,
            captions: false,
            transitions: transitionsArray,
            width: 320,
            height: 300
            //   delay: 2000
        });
       // $('.coin-slider').coinslider({ width: 280, height: 187, navigation: false, delay: 3000, spw: 4, sph: 4 });
    }


}
