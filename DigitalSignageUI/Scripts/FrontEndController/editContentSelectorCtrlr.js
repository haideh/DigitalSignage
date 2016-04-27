function editContentSelectorCtrlr($scope, httpRequest) {

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
                    $scope.runPlayer(contenDetailObjList);
                }

                contentObj.itemList = contenDetailObjList;

                resultList.push(contentObj);
            }
        });

        return resultList;
    };

    $scope.loadAdsList = function () {//all

        $scope.resultList = [];
        var dataObj = new Object();
        dataObj.type = $scope.type;

        $scope.resultList = $scope.adsItemDetailListCreator(service_loadAdsItemListWithType, dataObj, 'ads');

    };


    $scope.loadContentAdsList = function () {

        $scope.resultAdsContentList = [];
        var dataObj = new Object();
        dataObj.type = $scope.type;
        dataObj.contentId = $scope.contentId;
        dataObj.position = $scope.position;

        $scope.resultAdsContentList = $scope.adsItemDetailListCreator(service_loadContentAdsListWithPoition, dataObj, 'content');
    };

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

    $scope.showAdsInf = function () {
        // $(".panelToggle").css("display", "block");
    }

    $scope.editPackageTime = function () {
        var index = $scope.resultAdsContentList.indexOf($scope.selectedPackage);
        $scope.resultAdsContentList[index].interval = $scope.selectedPackage.interval;
        $scope.clearSelectPackageInf();
        //  $(".panelToggle").css("display", "none");
    }

    $scope.saveAdsItemPackage = function () {
        var obj = new Object();

        obj.position = $(".positionInp").val();
        obj.content_id = $(".contentIdInp").val();
        obj.interval = $scope.selectedPackage.interval;
        obj.adsItemList = new Array();
        obj.adsItemList = $scope.resultAdsContentList;
        debugger
        //angular.forEach($scope.loadContentAdsList, function (value, key) {
        //    obj.adsItemList.push(value);
        //});

        httpRequest.post(service_editContentAds, obj, function (data) {
        });
        location.href = "/Edit/EditContent?contentId=" + obj.content_id;
    }

    $scope.load = function () {

        $scope.contentId = '';
        $scope.type = '';
        $scope.position = '';
        $scope.contentId = $(".contentIdInp").val();
        $scope.type = $(".typeInp").val();
        $scope.position = $(".positionInp").val();
        $scope.selectedPackage = [];
        $scope.adsList = [];

        $scope.loadAdsList();//all
        $scope.loadContentAdsList();

    }
    $scope.load();


    $scope.keyUpImageList = function () {
        sinageAutocomplte('serach-result', 'search');
    }

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


        //url = rtmpSource + rtmpStreamName;
        //var simulateiDeviceFlag = /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent);
        //if (simulateiDeviceFlag)
        //    url = androidUrlSource + androidStreamName;

        //// some code..
        //var player = $f(".flowplayerVideo", flowPlayerSWF, {
        //    clip: {
        //        //    url: androidUrlSource + androidStreamName,
        //        url: url,
        //        ipadUrl: iosUrlSource + iosStreamName,
        //        scaling: 'full',
        //        provider: 'rtmp',
        //        live: true,
        //        autoPlay: true,
        //        accelerated: true,
        //        autoBuffering: true,
        //        // use smil and bwcheck when resolving the clip URL
        //        //      urlResolvers: ['smil', 'bwcheck']
        //    },
        //    play: { opacity: 0 },

        //    plugins: {
        //        // the SMIL plugin reads in and parses the SMIL, and provides
        //        // the bitrates info to the bw detection plugin
        //        //        smil: { url: 'flowplayer.smil-3.2.9.swf' },
        //        // bandwidth check plugin
        //        bwcheck: {
        //            url: bwChkSource,
        //            // HDDN uses Wowza servers
        //            serverType: 'wowza',
        //            // we use dynamic switching, the appropriate bitrate is switched on the fly
        //            dynamic: true,
        //            netConnectionUrl: rtmpSource,
        //        },

        //        rtmp: {
        //            url: rtmpFlowSwf,
        //            netConnectionUrl: rtmpSource
        //        },
        //        canvas: {
        //            backgroundGradient: 'none'
        //        }
        //    }
        //}).ipad({ simulateiDevice: simulateiDeviceFlag });



    };
}
