service_loadContentsWithAdsItemDetail = "/show/loadContent";
service_loadAdsItemListWithType = "/edit/loadAdsListWithType";
service_loadContentAdsListWithPoition = "/edit/loadContentAdsListWithPoition";
service_loadWidgetAdsItemListWithType = "/edit/loadWidgetAdsItemListWithType";
service_editContentAds = "/edit/editContentAds";
service_deleteContentAds = "/edit/deleteContentAds";
service_editContentLives = "/edit/editContentLives";

service_loadLiveVedio = "/edit/loadLiveVedio";
service_loadLiveVedioContentWithPosition = "/edit/loadLiveVedioContentWithPosition";
service_loadContentLiveVedio = "/edit/loadContentLiveVedio";

service_isDirty="/show/isDirty"

service_addAds = "/ads/saveAds";
service_uploadFile = "/ads/uploadFile";
service_adsList = "/ads/getAdsList";
service_deladsFile = "/ads/deleteFile";
service_deladsWithDetail = "/ads/deleteAdsWithdetail";
service_editadsWithDetail = "/ads/editadsWithDetail";

service_login="/login/LoginFunction";
service_signUp = "/login/SignUpFunction";
service_logOut = "/login/Logout";

service_getTvInfo = "/show/getTvInfo"


//videoSource = 'http://localhost:14985/Modules/DigitalSignage/data/ads/movies/';
//imageSource = 'http://localhost:14985/modules/DigitalSignage/data/ads/images/';

adsSource = 'data/ads/';


defaultVideoSource = 'http://192.168.88.233:8080/modules/general/thumbnail_width.aspx?width=100&file=/Modules/DigitalSignage/data/ads/images/video.jpg';


packageImageSource = 'http://localhost:14985/modules/general/thumbnail_width.aspx?width=45&file=/Modules/DigitalSignage/data/ads/images/';
packageLiveImageSource = 'http://localhost:14985/modules/general/thumbnail_width.aspx?width=100&file=/Modules/DigitalSignage/data/ads/images/';

//------------------------------------------------vod--------------------------------------//
androidUrlSource = "http://192.168.88.20:1935/mediacache/mp4:http/sample.mp4";//vod
androidStreamName = "/manifest.f4m";

iosUrlSource = "http://192.168.88.20:1935/vod/mp4:sample.mp4";
iosStreamName = "/playlist.m3u8";


rtmpSource = "rtmp://192.168.88.20:1935/vod";
//rtmpSource = 'rtmp://192.168.88.20:1935/mediacache';//vod'
//rtmpStreamName = "/mp4:http/sample.mp4";

rtmpSourceVod = "rtmp://192.168.88.20:1935/mediacache";
rtmpStreamNameVod = "/mp4:http/sample.mp4";

//------------------------------------live----------------------------------------//
//androidUrlSource = 'http://192.168.88.20:1935/live/myStream'
//androidStreamName = '/manifest.f4m';

//iosUrlSource = 'http://192.168.88.20:1935/live/ch1.stream_360p';
//iosStreamName = '/playlist.m3u8';

//rtmpSource = 'rtmp://192.168.88.20:1935/live';
//rtmpStreamName = '/ch1.stream';
flowPlayerSWF = "/Skins/CSS_tvShow/flowPlayer/flowplayer-3.2.16.swf";
bwChkSource = "/Skins/CSS_tvShow/flowPlayer/flowplayer.bwcheck-3.2.13.swf";
rtmpFlowSwf = "/Skins/CSS_tvShow/flowPlayer/flowplayer.rtmp-3.2.12.swf";
httpstreamingLive = "/Skins/CSS_tvShow/flowPlayer/flowplayer.httpstreaminghls-live-3.2.15.swf";
bwcheck_httpstreaming = "/Skins/CSS_tvShow/flowPlayer/flowplayer.bwcheck_httpstreaming-3.2.13.swf";
httpstreaming = "/Skins/CSS_tvShow/flowPlayer/flowplayer.httpstreaming-3.2.10";
flowPlayerContent = "/Skins/CSS_tvShow/flowPlayer/flowplayer.content-3.2.9.swf";
flowPlayerControler = "/Skins/CSS_tvShow/flowPlayer/flowplayer.controls-3.2.15";
flowPlayerF4M = "/Skins/CSS_tvShow/flowPlayer/flowplayer.f4m-3.2.9.swf";
smilFlowPlayer = "/Skins/CSS_tvShow/flowPlayer/flowplayer.smil-3.2.9";
