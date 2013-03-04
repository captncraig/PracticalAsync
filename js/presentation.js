document.getElementById("impress").addEventListener( "impress:stepenter", function (event) {

    var step = event.target;

	if(step.id==='concurrency'){
		$(".remain").removeClass('remain');
		$("#conc").css('opacity','1');
		$("#conc").animate({"font-size":"600%"},1000);
	}
	if(step.id==='clone'){
		$("#conc").css('opacity','0');
	}

}, false);