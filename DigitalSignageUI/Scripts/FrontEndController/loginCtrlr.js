

application.controller('loginCtrlr', loginCtrlr);

function loginCtrlr($scope, httpRequest) {

    $scope.userInfo = [];

    $scope.load = function () {
        
    };
    $scope.load();


    $scope.loginFun = function () {
       
        httpRequest.post(service_login, $scope.userInfo, function (data) {
            setTimeout(function () {
                window.location.href = data.result.redirectUrl;
            }, 1000);
           
            });
    };
    $scope.signUpFunction = function () {
        
        $scope.userInfo.companyId = 1;
        httpRequest.post(service_signUp, $scope.userInfo, function (data) {
            
            window.location.href = data.Url;

        });
    };
   
    
}