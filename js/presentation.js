document.getElementById("impress").addEventListener( "impress:stepenter", function (event) {

    var step = event.target;
	var api = impress();
	if(step.id==='concurrency'){
		$(".word").removeClass('remain');
		$("#conc").css('opacity','1');
		api.next();
		$("#conc").animate({"font-size":"600%"},1000);
	}
	if(step.id==='synch'){
		$("#conc").css('opacity','0');
	}
	if(step.id==='scale'){
		$(".costs").removeClass('remain');
	}
	if(step.id==='synchReturn'){
		$(".gg").removeClass('remain');
		$("#synch").removeClass('future');
		$("#synch").addClass('past');
	}
	if(step.id==='synchReturn2'){
		$(".threads").removeClass('remain');
		$(".threads").removeClass('remainStrong');
		$("#synch").removeClass('future');
		$("#synch").addClass('past');
	}
	if(step.id==='synchReturn3'){
		$(".do").removeClass('remain');
		$("#synch").removeClass('future');
		$("#synch").addClass('past');
	}
	if(step.id==='do'){
		$(".what").removeClass('remain');
	}

}, false);