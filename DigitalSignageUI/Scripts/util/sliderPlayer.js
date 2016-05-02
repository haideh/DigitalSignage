runSlider = function () {
    //var transitionsArray = new Array();
    ////transitionsArray.push('bars','blinds','blocks','blocks2','concentric','slide','warp','zip','bars3d','blinds3d','cube','tiles3d','turn');
    //transitionsArray.push('bars', 'blinds', 'blocks', 'blocks2', 'concentric', 'slide', 'warp', 'zip', 'bars3d', 'blinds3d', 'cube', 'tiles3d', 'turn');
    ////var dlayArr = new Array();
    ////dlayArr.push(1000, 2000, 3000, 4000, 1000);
    //if (!flux.browser.supportsTransitions)
    //    alert("Flux Slider requires a browser that supports CSS3 transitions");
    //window.f = new flux.slider('.coin-slider', {
    //    pagination: false,
    //    //controls: true,
    //    captions: false,
    //    transitions: transitionsArray,
    //    width: '100%',
    //    height: '100%',
    //    delay: 2000
    //});
    $('.coin-slider').coinslider({ width: '100%', height: '100%', navigation: false, delay: 2000, spw: 4, sph: 4 });
}


runPlayer = function (itemList) {

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



   // url = videoSource + itemList[0].file_name;
   // var simulateiDeviceFlag = /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent);

    //if (simulateiDeviceFlag) {
    //    url = androidUrlSource + androidStreamName;
    //         url :url,
    //    $f(".flowplayerVideo", flowPlayerSWF, {
    //        clip: {
    //            url: url,
    //            ipadUrl: iosUrlSource + iosStreamName,
    //            scaling: 'full',
    //            provider: 'httpstreaming',
    //            live: true,
    //            autoPlay: true,
    //            accelerated: true,
    //            autoBuffering: true,
    //            // use smil and bwcheck when resolving the clip URL
    //            urlResolvers: ['httpstreaming', 'bwcheck', 'smil']
    //        },
    //        play: { opacity: 0 },

    //        plugins: {
    //            // the SMIL plugin reads in and parses the SMIL, and provides
    //            // the bitrates info to the bw detection plugin
    //            //httpstreaming: {
    //            //    url: httpstreamingLive,
    //            //    liveButton: true
    //            //},
    //            httpstreaming: { url: httpstreaming },
    //            smil: { url: smilFlowPlayer },
    //            // bandwidth check plugin
    //            bwcheck: {
    //                url: bwChkSource,
    //                // HDDN uses Wowza servers
    //                serverType: 'wowza',
    //                // we use dynamic switching, the appropriate bitrate is switched on the fly
    //                dynamic: true,
    //                netConnectionUrl: rtmpSource,
    //                // show the selected file in the content box. This is not used in real installations.
    //                onStreamSwitchBegin: function (newItem, currentItem) {
    //                    //$f("dynamic").getPlugin('content').setHtml("Will switch to: " + newItem.streamName +
    //                    //    " from " + currentItem.streamName);
    //                },
    //                onStreamSwitch: function (newItem) {
    //                    //$f("dynamic").getPlugin('content').setHtml("Switched to: " + newItem.streamName + " with bitrate: " + newItem.bitrate);
    //                    // $('#txtDetail').val("current br: " + newItem.bitrate + " Kbps");
    //                }
    //            },
    //            f4m: { url: flowPlayerF4M },
    //            controls: { url: flowPlayerControler },
    //            rtmp: {
    //                url: rtmpFlowSwf,
    //                netConnectionUrl: rtmpSource
    //            },
    //            // a content box so that we can see the selected bitrate. This is not normally
    //            // used in real installations.
    //            content: {
    //                url: flowPlayerContent,
    //                backgroundColor: 'transparent', backgroundGradient: 'none', border: 100,
    //                textDecoration: 'outline',
    //                style: {
    //                    body: {
    //                        fontSize: 14,
    //                        fontFamily: 'Arial',
    //                        textAlign: 'center',
    //                        color: '#ffffff'
    //                    }
    //                }
    //            },
    //            canvas: {
    //                backgroundGradient: 'none'
    //            }
    //        }

    //    }).ipad({ simulateiDevice: simulateiDeviceFlag });
    //}
    //else {

    //         url = rtmpSourceVod + rtmpStreamNameVod;
    //  //  url = videoSource + itemList[0].file_name;
    //    // some code..
    //    var player = $f(".flowplayerVideo", flowPlayerSWF, {
    //        clip: {
    //            //    url: androidUrlSource + androidStreamName,
    //            url: url,
    //            ipadUrl: iosUrlSource + iosStreamName,
    //            scaling: 'full',
    //            provider: 'rtmp',
    //            live: true,
    //            autoPlay: true,
    //            accelerated: true,
    //            autoBuffering: true,
    //            // use smil and bwcheck when resolving the clip URL
    //            //      urlResolvers: ['smil', 'bwcheck']
    //        },
    //        play: { opacity: 0 },

    //        plugins: {
    //            // the SMIL plugin reads in and parses the SMIL, and provides
    //            // the bitrates info to the bw detection plugin
    //            //        smil: { url: 'flowplayer.smil-3.2.9.swf' },
    //            // bandwidth check plugin
    //            bwcheck: {
    //                url: bwChkSource,
    //                // HDDN uses Wowza servers
    //                serverType: 'wowza',
    //                // we use dynamic switching, the appropriate bitrate is switched on the fly
    //                dynamic: true,
    //                netConnectionUrl: rtmpSource,
    //            },

    //            rtmp: {
    //                url: rtmpFlowSwf,
    //                netConnectionUrl: rtmpSource
    //            },
    //            canvas: {
    //                backgroundGradient: 'none'
    //            }
    //        }
    //    }).ipad({ simulateiDevice: simulateiDeviceFlag });
    //}
}