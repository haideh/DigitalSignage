function notifyAlert(errorMsg) {
    if (!$('.alert-box').length) {
        $('<div class="alert-box alert" >'+errorMsg+'</div>').prependTo('notify').delay(3000).fadeOut(1500, function () {
            $('.alert-box').remove();
        });
    };
};
function notifySuccess(successMsg) {
    
    if (!$('.alert-box').length) {
        $('<div class="alert-box success" >'+successMsg+'</div>').prependTo('notify').delay(3000).fadeOut(1500, function () {
            $('.alert-box').remove();
        });
    };
};
function notifyWarning(warningMsg) {
    if (!$('.alert-box').length) {
        $('<div class="alert-box warning" >'+warningMsg+'</div>').prependTo('notify').delay(3000).fadeOut(1500, function () {
            $('.alert-box').remove();
        });
    };
};
function notifyInfo(infoMsg) {
    if (!$('.alert-box').length) {
        $('<div class="alert-box info" >' + infoMsg + '</div>').prependTo('notify').delay(3000).fadeOut(1500, function () {
            $('.alert-box').remove();
        });
    };
};

function notifyFix() {
    if (!$('.alert-box-fix').length) {
        $('<div onClick="notifyFixClose()" class="alert-box-fix alert" ><span>نمایش پیام مورد نظر نمایش پیام مورد نظر</span>').prependTo('notify-fix');
    };
};

function notifyFixClose() {
    if ($('.alert-box-fix').length) {
        $('.alert-box-fix').delay(30).fadeOut(1000, function () { $('.alert-box-fix').remove() });
    };
};