if(typeof(simple)=="undefined"){
	var simple = {};
}

simple.validator = function(){
	//////////
	
	function validate(){
		var validateElementList=[];
		var validateResult=true;
		validateElementList = document.querySelectorAll("[s-validator-rules]");
		for(var i=0;i<validateElementList.length;i++){
			if(validateElement(validateElementList[i])==false){
				validateResult=false;
			}
		}
		return validateResult;
	}
	
	function validateElement(element){
		if(element.type!=="text"&&element.type!=="textarea"&&element.type!=="password"){
			alert("simple.validator发生错误：只支持验证文本类型的表单元素。\n\n错误产生于元素："+element+"\n不支持的表单元素类型："+element.type);
		}
		var validateValue=element.value;
		var validateResult=-10000;
		var validateRuleQuery=element.getAttribute("s-validator-rules");
		var validateRuleAndParamList=validateRuleQuery.split("|");
		var validateRuleList=[];
		var validateparamList=[];
		for(var i=0;i<validateRuleAndParamList.length;i++){
			validateRuleAndParamList[i]=validateRuleAndParamList[i];
			validateRuleList[i]=trim(validateRuleAndParamList[i].split(":")[0]);
			if(typeof(validateRuleAndParamList[i].split(":")[1])=="string"){
				validateparamList[i]=trim(validateRuleAndParamList[i].split(":")[1]);
			}else{
				validateparamList[i]="";
			}
			if(validateRuleList[i]!=""){
				if(rulesForRegex[validateRuleList[i]]){
					if(rulesForRegex[validateRuleList[i]](validateValue,validateparamList[i])){
						validateResult=Math.abs(validateResult);
					}else{
						validateResult--;
					}
				}else{
					alert("simple.validator发生错误：使用了不支持的验证规则。\n\n错误产生于元素："+element+"\n不支持的验证规则："+validateRuleList[i]);
				}
			}
		}
		if(validateResult>=-10000){
			element.temp_svalidatorFunctionBind = new Function(element.getAttribute("s-validator-onSucceed"));
			element.temp_svalidatorFunctionBind();
			element.temp_svalidatorFunctionBind=null;
			return true
		}else{
			element.temp_svalidatorFunctionBind = new Function(element.getAttribute("s-validator-onFail"));
			element.temp_svalidatorFunctionBind();
			element.temp_svalidatorFunctionBind=null;
			return false			
		}
				
	}
	
	//验证规则对应的函数
	var rulesForRegex={
		none:rulesForRegex_none,
		required:rulesForRegex_required,
		email:rulesForRegex_email,
		date:rulesForRegex_date,
		url:rulesForRegex_url,
		number:rulesForRegex_number,
		integer:rulesForRegex_integer,
		real:rulesForRegex_real,
		char:rulesForRegex_char,
		charNumber:rulesForRegex_charNumber,
		charNumber_:rulesForRegex_charNumber_,
		chinese:rulesForRegex_chinese
	}
	
	//验证函数
	function rulesForRegex_none(value,param){
		return value=="";
	}
	
	function rulesForRegex_required(value,param){
		var validateResult;
		if(trim(value)==""){
			validateResult=false;
		}else{
			validateResult=true;
		}
		if(validateResult&&param!=""){
			validateResult=checkString(value,param);
		}
		return validateResult;
	}
	
	function rulesForRegex_email(value,param){
		var regex= /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/ ;
		return regex.test(value);
	}
	
	function rulesForRegex_date(value,param){
		var validateResult;
		var regex= new RegExp("(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29)") ;
		validateResult = regex.test(value);
		if(validateResult&&param!=""){
			validateResult=checkDate(value,param);
		}
		return validateResult;
	}

	function rulesForRegex_url(value,param){
		var regex= /^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i;
		return regex.test(value);		
	}
	
	function rulesForRegex_number(value,param){
		var validateResult;
		var regex= /^\d+$/ ;
		validateResult = regex.test(value);
		if(validateResult&&param!=""){
			validateResult=checkString(value,param);
		}
		return validateResult;
	}
	
	function rulesForRegex_integer(value,param){
		var validateResult;
		var regex= /^-?\d+$/;
		validateResult = regex.test(value);
		if(validateResult&&param!=""){
			validateResult=checkValue(value,param);
		}
		return validateResult;	
	}
	
	function rulesForRegex_real(value,param){
		var validateResult;
		var regex= /^(-?\d+)(\.\d+)?$/;
		validateResult = regex.test(value);
		if(validateResult&&param!=""){
			validateResult=checkValue(value,param);
		}
		return validateResult;
	}
	
	function rulesForRegex_char(value,param){
		var validateResult;
		var regex= /^[A-Za-z]+$/;
		validateResult = regex.test(value);
		if(validateResult&&param!=""){
			validateResult=checkString(value,param);
		}
		return validateResult;
	}
	
	function rulesForRegex_charNumber(value,param){
		var validateResult;
		var regex= /^[A-Za-z0-9]+$/;
		validateResult = regex.test(value);
		if(validateResult&&param!=""){
			validateResult=checkString(value,param);
		}
		return validateResult;	
	}
	
	function rulesForRegex_charNumber_(value,param){
		var validateResult;
		var regex= /^[A-Za-z0-9_]+$/;
		validateResult = regex.test(value);
		if(validateResult&&param!=""){
			validateResult=checkString(value,param);
		}
		return validateResult;		
	}
	
	function rulesForRegex_chinese(value,param){
		var validateResult;
		var regex= /^[\u0391-\uFFE5]+$/;
		validateResult = regex.test(value);
		if(validateResult&&param!=""){
			validateResult=checkString(value,param);
		}
		return validateResult;
	}
	
	//////////
	function trim(str) { return str.replace(/(^\s*)|(\s*$)/g, ""); } 
	function trimAll(str){ return str.replace(/[ ]/g,""); }
	
	function checkString(str,conditionQuery){
		var strLength = trim(str).length;
		var conditionList = trimAll(conditionQuery).split(",");
		var conditionRuleList = [];
		var conditionParamList = [];
		for(var i=0;i<conditionList.length;i++){
			if(conditionList[i].substr(0,2)==">="){
				conditionRuleList[i]=">="
				conditionParamList[i]=conditionList[i].substr(2);
			}else if(conditionList[i].substr(0,2)=="<="){
				conditionRuleList[i]="<="
				conditionParamList[i]=conditionList[i].substr(2);
			}else if(conditionList[i].substr(0,1)==">"){
				conditionRuleList[i]=">"
				conditionParamList[i]=conditionList[i].substr(1);
			}else if(conditionList[i].substr(0,1)=="<"){
				conditionRuleList[i]="<"
				conditionParamList[i]=conditionList[i].substr(1);
			}else if(conditionList[i].substr(0,1)=="="){
				conditionRuleList[i]="=="
				conditionParamList[i]=conditionList[i].substr(1);
			}else{
				alert("simple.validator发生错误：验证规则参数有误。");
			}
		}
		var conditionResult=true;
		for(var i=0;i<conditionRuleList.length;i++){
			eval(
				"if(strLength"+conditionRuleList[i]+conditionParamList[i]+"){}else{conditionResult=false}"
			)
		}
		return conditionResult;
	}
	
	function checkValue(value,conditionQuery){
		var conditionList = trimAll(conditionQuery).split(",");
		var conditionRuleList = [];
		var conditionParamList = [];
		for(var i=0;i<conditionList.length;i++){
			if(conditionList[i].substr(0,2)==">="){
				conditionRuleList[i]=">="
				conditionParamList[i]=conditionList[i].substr(2);
			}else if(conditionList[i].substr(0,2)=="<="){
				conditionRuleList[i]="<="
				conditionParamList[i]=conditionList[i].substr(2);
			}else if(conditionList[i].substr(0,1)==">"){
				conditionRuleList[i]=">"
				conditionParamList[i]=conditionList[i].substr(1);
			}else if(conditionList[i].substr(0,1)=="<"){
				conditionRuleList[i]="<"
				conditionParamList[i]=conditionList[i].substr(1);
			}else if(conditionList[i].substr(0,1)=="="){
				conditionRuleList[i]="=="
				conditionParamList[i]=conditionList[i].substr(1);
			}else{
				alert("simple.validator发生错误：验证规则参数有误。");
			}
		}
		var conditionResult=true;
		for(var i=0;i<conditionRuleList.length;i++){
			eval(
				"if(value"+conditionRuleList[i]+conditionParamList[i]+"){}else{conditionResult=false}"
			)
		}
		return conditionResult;
	}
	
	function checkDate(value,conditionQuery){
		var conditionList = trimAll(conditionQuery).split(",");
		var conditionRuleList = [];
		var conditionParamList = [];
		for(var i=0;i<conditionList.length;i++){
			if(conditionList[i].substr(0,2)==">="){
				conditionRuleList[i]=">="
				conditionParamList[i]=checkDate_date2Number(conditionList[i].substr(2));
			}else if(conditionList[i].substr(0,2)=="<="){
				conditionRuleList[i]="<="
				conditionParamList[i]=checkDate_date2Number(conditionList[i].substr(2));
			}else if(conditionList[i].substr(0,1)==">"){
				conditionRuleList[i]=">"
				conditionParamList[i]=checkDate_date2Number(conditionList[i].substr(1));
			}else if(conditionList[i].substr(0,1)=="<"){
				conditionRuleList[i]="<"
				conditionParamList[i]=checkDate_date2Number(conditionList[i].substr(1));
			}else if(conditionList[i].substr(0,1)=="="){
				conditionRuleList[i]="=="
				conditionParamList[i]=checkDate_date2Number(conditionList[i].substr(1));
			}else{
				alert("simple.validator发生错误：验证规则参数有误。");
			}
		}
		var conditionResult=true;
		var value2=checkDate_date2Number(value);
		for(var i=0;i<conditionRuleList.length;i++){
			eval(
				"if(value2"+conditionRuleList[i]+conditionParamList[i]+"){}else{conditionResult=false}"
			)
		}
		return conditionResult;
	}
	function checkDate_date2Number(date){
		var dateQuery=date.split("-");
		return parseInt(dateQuery[0])*10000+parseInt(dateQuery[1])*100+parseInt(dateQuery[2])*1;
	}
	
	//////////
	return {
		validate:validate
	}
}();
