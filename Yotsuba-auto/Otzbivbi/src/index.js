'use strict';
const goods = document.querySelector('.goods');
const cart_wrapper=document.querySelector('.cart-wrapper');
const checkmark = document.querySelector('.filter-check_checkmark');
let products = [];
let curentlyProducts = [];
const cart=document.querySelector('.cart');
let cartArr=[];
let totalAmount=0;
const total=document.querySelector(".total");
const counter=document.querySelector('.counter');
let totalProducts=0;
//
let sale=false;
let price=false;
/*const check */
console.dir(goods);
 let array = [];
 let arraysale=[];
 let arraypoisk=[];
 let arrayzena=[];
//
fetch('db/db.json')
.then((res)=>res.json())
.then((data)=>{
    console.dir(data);
    renderCards(data.goods);
    products = data.goods;
    curentlyProducts=data.goods;
    addCategory(products);
})
/**/
 fetch('db/db.json')/*'/papka/drop your stick/db.json'*//*127.0.0.1:5500/путь*/
  .then(function (response) {
    return response.json()
  })
  .then(function (data) {
   array[array.length]=data.goods;
    console.log('data', data)
    renderCards(data.goods);
  })
/**/
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

// function chengeIMG(id){
//     var imgs1 = document.getElementsByClassName('card-img-top');
//     var imgs2 = document.getElementsByClassName('card-img-back');
//     id = imgs1.length - id - 1;

//     var background = imgs1[id].style.backgroundImage;
//     imgs1[id].style.backgroundImage = imgs2[id].style.backgroundImage;
//     imgs2[id].style.backgroundImage = background;
// }

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




function zena(sale){
	let s1=document.getElementById("min").value;
	let s2=document.getElementById("max").value;
	/*alert(s1);
	alert(s2);*/
	if(s2!="" && s1==""){if(sale){arrayzena=arraysale.filter(card=>card.price<=s2);}else{arrayzena=array[array.length-1].filter(card=>card.price<=s2);}renderCards(arrayzena);}
	if(s1=="" && s2==""){if(sale){arrayzena=arraysale.filter(card=>card.price>=0);}else{arrayzena=array[array.length-1].filter(card=>card.price>=0);}renderCards(arrayzena);console.log(arrayzena);}
	if(s1!="" && s2==""){if(sale){arrayzena=arraysale.filter(card=>card.price>=s1);}if(!sale){arrayzena=array[array.length-1].filter(card=>card.price>=s1);}renderCards(arrayzena);console.log(arrayzena);}
	else{if (sale){arrayzena=arraysale.filter(card=>card.price>=s1);}else{arrayzena=array[array.length-1].filter(card=>card.price>=s1);}arrayzena=arrayzena.filter(card=>card.price<=s2);renderCards(arrayzena);}
	console.log("zena ",arrayzena);
}
function addToCart(el){
    let i=el.dataset.newid;
    cartArr.push(products[i]);
}

function renderCardBascket(){
    if(cartArr.length==0){
        cart_wrapper.insertAdjacentHTML('afterbegin',`<div id="cart-empty">
        В данный момент корзина пуста
        </div>`);
        total.innerHTML='';
        total.insertAdjacentHTML('afterbegin',0);
        return;
    }
    totalAmount=0;
    cartArr.forEach((card,id) => {
        cart_wrapper.insertAdjacentHTML('afterbegin',`
        <div class="card">
            <div class="card-img-wrapper">
                <span class="card-img-top"
                    style="background-image: url('${card.img}')"></span>
            </div>
            <div class="card-body justify-content-between">
                <div class="card-price">${card.price} &#8381;</div>
                <h5 class="card-title">${card.title}</h5>
                <button class="btn btn-primary remove" data-idd=${id}>Удалить из корзины</button>
            </div>
        </div>`);
        totalAmount+=card.price;
    });
    total.innerHTML='';
    total.insertAdjacentHTML('afterbegin',totalAmount);
    
}

function removeFromBascket(el){
    cartArr.forEach((card,id) =>{
        if(el.dataset.idd==id){
            cartArr.splice(id,1);
        }
    });
    cart_wrapper.innerHTML='';
    renderCardBascket();
}
function sas(){
	let arrt=[];
	cartArr=arrt;
	renderCardBascket;
}