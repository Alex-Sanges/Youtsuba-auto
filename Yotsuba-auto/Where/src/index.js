let array = [];
fetch('db.json')/*'/papka/drop your stick/db.json'*//*127.0.0.1:5500/путь*/
  .then(function (response) {
    return response.json()
  })
  .then(function (data) {
   array/*[array.length]*/=data.orders;
    //console.log('data', data)
	//console.log('sas',array[0].Name);
  })
function renderCards(collection){
goods.innerHTML = '';
    collection.forEach((card,id) => {
        goods.insertAdjacentHTML('afterbegin',`<div class="Otz">
			<img src="${card.img[0]}" class="Pht_Cr" alt="">
				<div class="card">
                    <p class="Name">${card.Name} </p>
					<p class="txt">${card.Text}</p>
					<p class="Dt">${card.Date}</p>
				</div>
		</div>`);
})
}

function imageList(imgs) {
    var str = "";
    for (var i = 1; imgs.length>i; i++)
        str += '<img src="'+imgs[i]+'" alt="">';
    return str;
}
function chengeIMG(id){
    var sliders = document.getElementsByClassName('slides');
    var bts = document.getElementsByClassName('btnNext');
    id = sliders.length - id - 1;
    // Берём слайды
    let slider = sliders[id].querySelectorAll("img");

    // Условие если переменная i больше или равна количеству слайдов
    for (var i = 0; i < slider.length; i++) {
        if (slider[i].classList.contains("block")) {
            slider[i].classList.remove("block");
            if (++i >= slider.length)
                i = 0;
            slider[i].classList.add("block");
            bts[id].style.marginLeft = 40 * i + 'px';
            return;
        }
    }
}
function doit(){
	var uncord = document.getElementById('uncord');
	uncord.style.display = 'none';
	var hid = document.getElementById('hidden');
	hid.style.display = 'none';
	let input = document.querySelector('input');
	/*console.log(input.value);*/
	input=(input.value.toLowerCase());
	console.log(input);
	let order=[];
	for (var i=0; i<=array.length-1; i++) {
	// if (person.children[i].hasOwnProperty(key)) {
    //i = индекс
    //значение = person.children[i]
	(input==array[i].Name)?/*console.log("Элемент [ "+ i +" ] = " + array[i].Name+" !=! "+input)*/order=array[i] : console.log("Элемент [ "+ i +" ] = " + array[i].Name);
	// }	
	}
		(order.length==0)?/*console.log("Заказ с таким Трек-номером не обнаружен. Убедитесь в правильности ввода и попробуйте ещё раз.")*/ uncorrectNumber():correctNumber(order);		
}
//const goods = document.querySelector('.orders');
function uncorrectNumber(){
	var uncord = document.getElementById('uncord');
	uncord.style.display = 'block';
}
function correctNumber(ord){
	var hid = document.getElementById('hidden');
	hid.style.display = 'block';
	var hid=document.getElementById('number');
	hid.innerHTML=ord.Name;
	var hid=document.getElementById('auto');
	hid.innerHTML=ord.Auto;
	var hid=document.getElementById('data');
	hid.innerHTML=ord.Date;
	var hid=document.getElementById('order');
	hid.innerHTML=ord.Text;
	document.getElementById('car').src = ord.img[0];
	console.dir(ord.img[0]);
}