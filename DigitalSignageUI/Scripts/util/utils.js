function freeCatch(){
	sessionStorage.clear();
	localStorage.clear();
};
function openFancys (fancyID){

	$('#'+fancyID).foundation('reveal','open');
};
function closeFancys (fancyID){

	$('#'+fancyID).foundation('reveal','close');
};
function toggelFoldingPanel (panelID){
	$('#'+panelID).slideToggle("fast");
};
getPaginationObject = function(pageNumber , pageSize){

	var paginationObject = new Object();
	paginationObject.pageNumber = pageNumber;
	paginationObject.pageSize  = pageSize;

	return paginationObject;
};
getPaging = function(data ,pageSize, pagingUl){

	//how much items per page to show  
	var show_per_page = pageSize;  
	//getting the amount of elements inside content div  
	var number_of_items = data;  
	//calculate the number of pages we are going to have  
	var number_of_pages = Math.ceil(number_of_items/show_per_page); 

	sessionStorage.number_of_pages = null;
	sessionStorage.setItem("number_of_pages",  number_of_pages);

	$(pagingUl).find('li').remove();

	var navigation_html = "<li class='arrow'><a href='javascript:previous()'>&laquo;</a></li>";  
	var current_link = 0; 
	// var pageCount = new Object();
	if(number_of_pages <= 5){
		while(number_of_pages > current_link){ 
			if(current_link == 0)
				navigation_html += '<li id="' + current_link +'" class="current page_link"><a href="javascript:paginationClick(' +current_link +')">'+ (current_link + 1) +'</a></li>';  
			else
				navigation_html += '<li id="' + current_link +'" class="page_link"><a href="javascript:paginationClick(' + current_link +')">'+ (current_link + 1) +'</a></li>'; 

			current_link++;
		}
	}else{

		while(5 > current_link){ 
			if(current_link < number_of_pages){

				if(current_link == 0)
					navigation_html += '<li id="' + current_link +'" class="current page_link"><a href="javascript:paginationClick(' +current_link +')">'+ (current_link + 1) +'</a></li>';  
				else
					navigation_html += '<li id="' + current_link +'" class="page_link"><a href="javascript:paginationClick(' + current_link +')">'+ (current_link + 1) +'</a></li>'; 

				current_link++;
			}
		}
		navigation_html += "<li>...</li>";
	}


	navigation_html += ' <li class="arrow"><a href="javascript:next()">&raquo;</a></li>';  
	$(pagingUl).append(navigation_html);

	$(pagingUl+' .current:first').addClass('active_page');
	$('#current_page').val(0);

};


previous = function(){  

	var currentTable = sessionStorage.getItem("pagination");
	var page="pagination";

	new_page = parseInt($(currentTable+" #current_page").val()) - 1;  
	page = "._"+ currentTable.split("_",2)[1];
	

	var numberOfPage = sessionStorage.getItem("number_of_pages");

	if(new_page > -1){
		if($(page+' li.current').prev('.page_link').length==true){  
			paginationClick(new_page ,"pagination");  
		} 
		else if(new_page % 5 > 0){
			$(page).find('li').remove();
			var current_link = new_page; 
			var navigation_html = "<li class='arrow'><a href='javascript:previous()'>&laquo;</a></li>";  

			if(current_link <5 ){
				for(var i = 0 ; i <= current_link ; i++)
				{
					navigation_html += '<li id="' + i +'" class="page_link"><a href="javascript:paginationClick(' + i +')">'+ (i + 1) +'</a></li>'; 
				}
				if(current_link != 0)
					navigation_html += "<li>...</li>";	
			}else{
				if(current_link != 0)
					navigation_html += "<li>...</li>";	
				for(var i = current_link-4 ; i <= current_link ; i++)
				{
					navigation_html += '<li id="' + i +'" class="page_link"><a href="javascript:paginationClick(' + i +')">'+ (i + 1) +'</a></li>'; 

				}
				if(current_link != numberOfPage)
					navigation_html += "<li>...</li>";
			}
//			}
			navigation_html += ' <li class="arrow"><a href="javascript:next()">&raquo;</a></li>';  
			$(page).prepend(navigation_html);
			$(page+' .current:first').addClass('active_page');

			paginationClick(new_page , "pagination"); 
		}

	}


}; 

next = function(){
	var currentTable = sessionStorage.getItem("pagination");
	var page="";

	new_page = parseInt($(currentTable+" #current_page").val()) + 1;  
	page = "._"+ currentTable.split("_",2)[1];

	var numberOfPage = sessionStorage.getItem("number_of_pages");

	if(numberOfPage > new_page){
		if(new_page % 5 == 0){
			$(page).find('li').remove();
			var navigation_html = "<li class='arrow'><a href='javascript:previous()'>&laquo;</a></li>";  
			var current_link = new_page; 

			if(current_link != 1)
				navigation_html += "<li>...</li>";
			while(5+new_page > current_link){ 
				if(current_link < numberOfPage)
					navigation_html += '<li id="' + current_link +'" class="page_link"><a href="javascript:paginationClick(' + current_link +')">'+ (current_link + 1) +'</a></li>'; 
				current_link++;

			}
			if(current_link != numberOfPage)
				navigation_html += "<li>...</li>";
			navigation_html += ' <li class="arrow"><a href="javascript:next()">&raquo;</a></li>';  
			$(page).append(navigation_html);
			$(page+' li.current:first').addClass('active_page');

			paginationClick(new_page , "pagination"); 
		}
		//if there is an item after the current active link run the function  
		else if($(page+' li.current').next('.page_link').length==true){  
			paginationClick(new_page ,"pagination");  
		}  
	}
};  

getSortList = function(propertyName , ascending){

	var sortListItem = new Array();
	sortListItem[0] = new Object();
	sortListItem[0].propertyName = propertyName;
	sortListItem[0].ascending = ascending;

	return sortListItem;
};

deleteBox = function(table , tableSearch){

	$("."+table+" input[type=text]").each(function() {
		$(this).val('');
	});
	//add by Ganjyar for del close icon
	$('table.'+tableSearch +'input').each(function(){
		$(this).removeClass('x');
		$(this).css({'background': ''});
	});
	if($(".selectEnvelopeType"))
		$(".selectEnvelopeType").attr("data-icon",'A');

	if($(".iSelectEnvelopeSendStatus")){
		$(".iSelectEnvelopeSendStatus").attr("data-icon",'A');
		$(".tSelectEnvelopeSendStatus").text('تمامی موارد');
	}

	if($(".iSelectEnvelopeReplyStatus")){
		$(".iSelectEnvelopeReplyStatus").attr("data-icon",'A');
		$(".tSelectEnvelopeReplyStatus").text('تمامی موارد');
	}

};

function successMsg(container){
	alert(Success_msg, "success", container);
}
function failMsg(container){
	alert(Error_msg, "alert", container);
}

//function createSortFields(scope_sortField ,sortField ,scope_order ,scope_iconOrder){

//if(scope_sortField=='' || scope_sortField!=sortField){
//scope_sortField=sortField;
//scope_order=false;
//}
//else if (scope_sortField == sortField)
//{

//if (scope_order == false){
//scope_order = true;
//scope_iconOrder="/form/images/arrow.png";
//}
//else if (scope_order == true){
//scope_order = 'non';
//scope_iconOrder="/form/images/logo180f.png";
//}
//else if (scope_order == 'non'){

//scope_order = false;
//scope_iconOrder='&#xe256;';
//}
//}
//}
function createSortFieldsIcon(scope_order , sortField){

	$('span').closest('th').removeClass('select');
	$('span.non').show();
	$('span.true').hide();
	$('span.false').hide();
	if(scope_order != 'non')
		$('span.'+sortField).closest('th').addClass('select');
	$('span.'+sortField).hide();
	$('span.non.'+sortField).show();
	$('span.'+sortField+'.non').hide();
	$('span.'+sortField+'.'+scope_order).show();
}

///disable ctrl+s
document.addEventListener("keydown", function(e) {
	if (e.keyCode == 83 && (navigator.platform.match("Mac") ? e.metaKey : e.ctrlKey)) {
		e.preventDefault();
		// Process event...
	}
}, false);

///disable ctrl+c
document.addEventListener("keydown", function(e) {

	var ctrlKey = 17,  cKey = 67;
	if (e.keyCode == ctrlKey) ctrlDown = true;
	if (e.keyCode == ctrlKey) ctrlDown = false;

	if (e.keyCode == cKey && (navigator.platform.match("Mac") ? e.metaKey : e.ctrlKey))   {
		e.preventDefault();
	}

}, false);

///disable ctrl+v
document.addEventListener("keydown", function(e) {

	var ctrlKey = 17, vKey = 86;
	if (e.keyCode == ctrlKey) ctrlDown = true;
	if (e.keyCode == ctrlKey) ctrlDown = false;

	if (e.keyCode == vKey && (navigator.platform.match("Mac") ? e.metaKey : e.ctrlKey))   {
		e.preventDefault();
	}

}, false);


getSortList = function(propertyName , ascending){

	var sortListItem = new Array();
	sortListItem[0] = new Object();
	sortListItem[0].propertyName = propertyName;
	sortListItem[0].ascending = ascending;

	return sortListItem;
};

function openPageAndPostDataObj(page, params){
	

	$(".myForm").remove();
	var form = document.createElement("form");
	form.setAttribute("method", "post");
	form.setAttribute("action", page);
	form.setAttribute("class", "myForm");
	form.setAttribute("target", "_blank");

	var hiddenField = document.createElement("input"); 
	hiddenField.setAttribute("type", "hidden");
	hiddenField.setAttribute("name", Object.keys(params));
	hiddenField.setAttribute("id", params[Object.keys(params)]);
	var dataObj =  Object.keys(params);
	for (var i = 0; i < dataObj.length; i++) {
		var _params = params[dataObj[i]];

		if(typeof(_params) == "object")
			hiddenField.setAttribute((dataObj[i]).toLowerCase(), JSON.stringify(_params));	
		else{
			hiddenField.setAttribute((dataObj[i]).toLowerCase(), _params);	
		}
	}

	form.appendChild(hiddenField);
	document.body.appendChild(form);

//	window.open('');
	$(".myForm").addClass('hide');
	form.submit();
}


//function openPageAndPostDataObj(page, params ,option){



//$(".myForm").remove();
//var form = document.createElement("form");
//form.setAttribute("method", "post");
//form.setAttribute("action", page);
//form.setAttribute("class", "myForm");
//form.setAttribute("target", "_blank");

//var hiddenField = document.createElement("input"); 
//hiddenField.setAttribute("type", "hidden");
//hiddenField.setAttribute("name", Object.keys(params));
//hiddenField.setAttribute("id", params[Object.keys(params)]);
//var dataObj =  Object.keys(params[Object.keys(params)]);
//for (var i = 0; i < dataObj.length; i++) {
//if(dataObj[i] == 'passenger'){

//var passengerObj = Object.keys(params[Object.keys(params)][dataObj[i]]);
//for (var p = 0; p< passengerObj.length; p++) {
//if(typeof(params[Object.keys(params)][dataObj[i]]) == 'object'){
////birthPlace
//if((params[Object.keys(params)][dataObj[i]]).birthPlace.name != undefined)
//hiddenField.setAttribute('passengerbirthplace', (params[Object.keys(params)][dataObj[i]]).birthPlace.name);//issuePlace;
//if((params[Object.keys(params)][dataObj[i]]).issuePlace.name != undefined)
//hiddenField.setAttribute('passengerissueplace', (params[Object.keys(params)][dataObj[i]]).issuePlace.name);
//if((params[Object.keys(params)][dataObj[i]]).nationalCode != undefined)
//hiddenField.setAttribute('passengernationalcode', (params[Object.keys(params)][dataObj[i]]).nationalCode);		
//if((params[Object.keys(params)][dataObj[i]]).firstName != undefined)
//hiddenField.setAttribute('passengerfirstname', (params[Object.keys(params)][dataObj[i]]).firstName)
////else
////hiddenField.setAttribute('passengerfirstname','');
//if((params[Object.keys(params)][dataObj[i]]).lastName != undefined)
//hiddenField.setAttribute('passengerlastname', (params[Object.keys(params)][dataObj[i]]).lastName);	
//if((params[Object.keys(params)][dataObj[i]]).fatherName != undefined)
//hiddenField.setAttribute('passengerfathername', (params[Object.keys(params)][dataObj[i]]).fatherName);
//if((params[Object.keys(params)][dataObj[i]]).SSN != undefined)
//hiddenField.setAttribute('passengerssn', (params[Object.keys(params)][dataObj[i]]).SSN);
//if((params[Object.keys(params)][dataObj[i]]).birthDate != undefined)
//hiddenField.setAttribute('passengerbirthdate', (params[Object.keys(params)][dataObj[i]]).birthDate);
////hiddenField.setAttribute('passengermiladiBirthDate', (params[Object.keys(params)][dataObj[i]]).miladiBirthDate);
//hiddenField.setAttribute('passengermiladibirthdate', '');
//if((params[Object.keys(params)][dataObj[i]]).gender != undefined)
//hiddenField.setAttribute('passengergender', (params[Object.keys(params)][dataObj[i]]).gender);
//if((params[Object.keys(params)][dataObj[i]]).nationality.name != undefined)
//hiddenField.setAttribute('passengernationality', (params[Object.keys(params)][dataObj[i]]).nationality.name);
//if((params[Object.keys(params)][dataObj[i]]).passportNo != undefined)
//hiddenField.setAttribute('passengerpassportno', (params[Object.keys(params)][dataObj[i]]).passportNo);
//}
//else
//hiddenField.setAttribute('passenger1', params[Object.keys(params)][dataObj[i]]);
//}
//}
//else if(dataObj[i] == 'border'){
//var borderObj = Object.keys(params[Object.keys(params)][dataObj[i]]);
//for (var b = 0; b< borderObj.length; b++) {
//if(typeof(params[Object.keys(params)][dataObj[i]]) == 'object')
//hiddenField.setAttribute('border', (params[Object.keys(params)][dataObj[i]]).name);
//else
//hiddenField.setAttribute('border1', params[Object.keys(params)][dataObj[i]]);
//}			
//}
//else if(dataObj[i] == 'source'){
//var sourceObj = Object.keys(params[Object.keys(params)][dataObj[i]]);
//for (var s = 0; s< sourceObj.length; s++) {
//if(typeof(params[Object.keys(params)][dataObj[i]]) == 'object')
//hiddenField.setAttribute('source', (params[Object.keys(params)][dataObj[i]]).name);
//else
//hiddenField.setAttribute('source1', params[Object.keys(params)][dataObj[i]]);
//}			
//}
//else if(dataObj[i] == 'destination'){
//var destinationObj = Object.keys(params[Object.keys(params)][dataObj[i]]);
//for (var d = 0; d< destinationObj.length; d++) {
//if(typeof(params[Object.keys(params)][dataObj[i]]) == 'object')
//hiddenField.setAttribute('destination', (params[Object.keys(params)][dataObj[i]]).name);
//else
//hiddenField.setAttribute('destination1', params[Object.keys(params)][dataObj[i]]);
//}			
//}
//else if(dataObj[i] == 'issuePlace'){
//if(typeof(params[Object.keys(params)][dataObj[i]]) != "string"){
//var issuePlaceObj = Object.keys(params[Object.keys(params)][dataObj[i]]);
//for (var ip = 0; ip< issuePlaceObj.length; ip++) {
//if(typeof(params[Object.keys(params)][dataObj[i]]) == 'object')
//hiddenField.setAttribute('issueplace', (params[Object.keys(params)][dataObj[i]]).name);
//else
//hiddenField.setAttribute('issueplace1', params[Object.keys(params)][dataObj[i]]);
//}
//}
//else{
//if(params[Object.keys(params)][dataObj[i]] != undefined)
//hiddenField.setAttribute((dataObj[i]).toLowerCase(), params[Object.keys(params)][dataObj[i]]);		
//}
//}
//else if(dataObj[i] == 'birthPlace'){

//if(typeof(params[Object.keys(params)][dataObj[i]]) != "string"){
//var birthPlaceObj = Object.keys(params[Object.keys(params)][dataObj[i]]);
//for (var bp = 0; bp< birthPlaceObj.length; bp++) {
//if(typeof(params[Object.keys(params)][dataObj[i]]) == 'object')
//hiddenField.setAttribute('birthplace', (params[Object.keys(params)][dataObj[i]]).name);
//else
//hiddenField.setAttribute('birthplace1', params[Object.keys(params)][dataObj[i]].name);
//}			

//}
//else{
//hiddenField.setAttribute((dataObj[i]).toLowerCase(), params[Object.keys(params)][dataObj[i]]);		
//}
//}

//else{
//hiddenField.setAttribute((dataObj[i]).toLowerCase(), params[Object.keys(params)][dataObj[i]]);		
//}
//};
//if(option != null){
//var _option = JSON.parse(option)[0];

//hiddenField.setAttribute('appserialnumber',_option.application.serialNumber);
//hiddenField.setAttribute('appnumber',_option.number);
//hiddenField.setAttribute('apptype',_option.type);
//hiddenField.setAttribute('appissuancedate',_option.issuanceDate);
//hiddenField.setAttribute('appissuanceplace',_option.issuancePlace);//lostDate
//hiddenField.setAttribute('applostdate',_option.lostDate);
//hiddenField.setAttribute('applostplace',_option.lostPlace);

//}
//form.appendChild(hiddenField);
//document.body.appendChild(form);

////window.open('');

//if(chkPopUpBlocker(page))
//form.submit();
//}

function openPageAndPostData(page, params){

	$(".myForm").remove();
	var form = document.createElement("form");
	form.setAttribute("method", "post");
	form.setAttribute("action", page);
	form.setAttribute("class", "myForm");
	form.setAttribute("target", "_blank");

//	for (var i = 0; i < Object.keys(params).length; i++) {

	var hiddenField = document.createElement("input"); 
	hiddenField.setAttribute("type", "hidden");
	hiddenField.setAttribute("name", Object.keys(params));
	hiddenField.setAttribute("id", params['id']);
	hiddenField.setAttribute("value", params['id']);
	form.appendChild(hiddenField);
	document.body.appendChild(form);
	
//	};

//	window.open('');
//	if(chkPopUpBlocker(page))
	form.submit();
}
function setSelectableGrid(tbl){
	$('table#' + tbl + ' > tbody tr').click(function(){
		$('table#' + tbl + ' > tbody tr').removeClass('select');
		$(this).addClass('select');
	});

	$('table#'+tbl+'> tbody tr').keynavigator({
		activeClass: 'select',
		keys: {
			13: function($el, cellIndex, e) {    
				console.log('pressed "enter"', arguments);
			}
		}
	});
}

function getRolesArray(roles){
	var routRoles = new Array(); 
	var tmpObj = new Object();
	if(roles.isSodour != undefined){
		tmpObj = new Object();
		tmpObj = 'isSodour';	
		routRoles.push(tmpObj);
	}
	if(roles.isTaradod != undefined){
		tmpObj = new Object();
		tmpObj = 'isTaradod';	
		routRoles.push(tmpObj);	
	}
	if(roles.isAdmin != undefined){
		tmpObj = new Object();
		tmpObj = 'isAdmin';	
		routRoles.push(tmpObj);	
	}
	if(roles.isSabt != undefined){
		tmpObj = new Object();
		tmpObj = 'isSabt';	
		routRoles.push(tmpObj);				
	}
	if(roles.isMalekan != undefined){
		tmpObj = new Object();
		tmpObj = 'isMalekan';	
		routRoles.push(tmpObj);				
	}
	return routRoles;
}

function chkPopUpBlocker(page){

	var popup = window.open(page,"","",true);
	setTimeout( function() {
		if(!popup || popup == undefined) {
			//if(window.outerHeightt === 0) {
			//First Checking Condition Works For IE & Firefox
			//Second Checking Condition Works For Chrome
			//	alert("Popup Blocker is enabled! Please add this site to your exception list.");
			$("#systemMsgModal").text('لطفا PopUp Blocker  مرورگر خود را فعال نمایید');
			$("#dialogAlarm").fadeIn();
			return false;
			//  window.location.href = 'warning.html';
		} 
		else if(popup.outerHeight === 0){
			//	alert("Popup Blocker is enabled! Please add this site to your exception list.");
			$("#systemMsgModal").text('لطفا PopUp Blocker  مرورگر خود را فعال نمایید');
			$("#dialogAlarm").fadeIn();
			return false;
		}
		else {
			//Popup Blocker Is Disabled
			//	popup.open('','_blank');
			popup.close();
			return true;
			//  window.close();
		} 

	}, 25);
	popup.close();
	return true;
}

function replaceAll(string, find, replace) {
	while (string.indexOf(find) > -1)
		string = string.replace(find, replace);
	return string;
}

function closeSystemMsgModal(){
	$("#dialogAlarm").fadeOut();
}


function selectTab(_menueBar) {

	$("ul._menueBar > li a").click(function(){
		$("ul._menueBar > li").removeClass('barTopSelect');
		$(this).closest('li').addClass('barTopSelect');
	});
}
function automaticSelectTab(_menueBar , currentLi) {

	$("ul._menueBar > li").removeClass('barTopSelect');
	$("."+currentLi).closest('li').addClass('barTopSelect');

}

function removeAnKeyFromObject(gridData , prop) {
	delete gridData[prop];
}

function checkNullStrIngModel(example) {
//	******************************remove "" element from model **************************************//
	for ( var element in example) {
		if(example[element] == "")
			example[element] = null;
		for ( var iterable_element in example[element]) {
			if(example[element][iterable_element] == "")
				example[element][iterable_element] = null;
			for ( var iterable_elem in example[element][iterable_element]) {
				if(example[element][iterable_element][iterable_elem] == "")
					example[element][iterable_element][iterable_elem] = null;
			}
		}
	}
	
	return example;
}

sinageAutocomplte = function (containerCls , inputID) {
    $("." + containerCls).hide();
    var keyword = $("#"+inputID).val();
    if (keyword != "") {
        $("."+containerCls+"[data-title*='" + keyword + "']").show();
    }
    else {
        $("." + containerCls).show();
    }
}


//remove item from array
//var index = $scope.resultList.indexOf(selectedAds);
//$scope.resultList.splice(index, 1);