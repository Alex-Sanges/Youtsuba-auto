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
        goods.insertAdjacentHTML('afterbegin',`<div class="col-12 col-md-6 col-lg-4 col-xl-3">
        <div class="card">
        ${card.sale ? '<div class="card-sale">&#128293;Hot sales!&#128293;</div>': ""}
            <div class="card-img-wrapper">
                <span class="card-img-top"
                    style="background-image: url('${card.img}')"></span>
            </div>
            <div class="card-body justify-content-between">
                <div class="card-price">${card.price} &#8381;</div>
                <h5 class="card-title">${card.title}</h5>
                <button class="btn btn-primary add" data-newid="${id}">В корзину</button>
            </div>
        </div>
    </div>`);
})
}

document.addEventListener('click',(elementDOM)=>{
    event.preventDefault();
    let el = elementDOM.target;
    
    /*if(el.classList.contains('filter-check_label-text') || el.classList.contains('filter-check_checkmark')){
        checkmark.classList.toggle('checked')
        if(checkmark.classList.contains('checked')){
            filterSale();
        }
        else
            renderCards(curentlyProducts);
            
    }*/
	if(el.classList.contains('filter-check_label-text') || el.classList.contains('filter-check_checkmark')){
            console.log("Найден");
			sale=!sale;
                filterSale(sale, price);
            checkmark.classList.toggle('checked');
            if(checkmark.classList.contains('checked')){
            }
        }
		//if(el.dataset.search=="search"){console.log("sasiska");console.log(document.getElementById("text").value);poisk(sale);}
		if(el.dataset.search=="primen"){zena(sale); price=true;}
	//
    if(el.parentElement.classList.contains('search-btn')){
        console.dir("button");
        filterSearch();
    }
    if(el.parentElement.classList.contains('catalog-button')||el.classList.contains('catalog-button_burger')){
        console.dir("Catalog");
        var list = document.querySelector('.catalog');
        list.classList.toggle('show');
    }
    if("id" in el.dataset){
        showCategory(el.dataset.id);
    }
    if(el.classList.contains('filterPrice')){
        filterPrice(curentlyProducts);
    }
    
    if(el.id=='cart' || el.classList.contains('desc')){
        cart.style='display:block;';
        renderCardBascket();
    }
    if(el.classList.contains('cart-close')){
        cart.style='display:none';
        cart_wrapper.innerHTML='';
        totalAmount=0;
        total.innerHTML='';
    }
    if(el.classList.contains('add')){
        addToCart(el);
        totalProducts++;
        counter.innerHTML=totalProducts;
    }
    if(el.classList.contains('remove')){
         totalProducts--;
         counter.innerHTML=totalProducts;
         removeFromBascket(el);
    }
	if(el.dataset.search=="zakaz"){
		totalProducts=0;
        counter.innerHTML=totalProducts;
		
		cart.style='display:none';
		console.dir("sas");sas();}
});


function filterSale(sale,price){
	console.log('sale', sale);
	if(sale && !price){arraysale=array[array.length-1].filter(card=>card.sale);}else if(!sale && !price){arraysale=array[array.length-1];}
	//sale=!sale;
	if(sale &&price){arraysale=arrayzena.filter(card=>card.sale);}
	if(!sale &&price){arraysale=arrayzena;}
  renderCards(arraysale);
}

function filterSearch(){
    let text=document.querySelector('.search-wrapper_input').value.trim();
    let regex=new RegExp(text,'i');
    let newProducts = products.filter(card=> regex.test(card.title));
    curentlyProducts=newProducts;
    renderCards(newProducts);
}

function addCategory(collection){
    let arr=[];
    collection.forEach(card=>{
        if(!arr.includes(card.category)){
            arr.push(card.category);
        }
    })
    console.dir(arr);
    var uls = document.querySelector('.catalog-list');
    var li;
       for (var i = 0; i < arr.length; i++) {
           li = document.createElement("li");
           li.innerText = arr[i];
           li.dataset.id=arr[i];
           uls.appendChild(li);
       }
       li = document.createElement("li");
       li.innerText="Все товары";
       li.dataset.id="All";
       uls.appendChild(li);
}
function showCategory(id){
    if(id=="All")
        curentlyProducts=products;
    else
        curentlyProducts=products.filter(card=>card.category==id);
    renderCards(curentlyProducts);
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
	/*let i==0;
	let zenca=0;
	(if i<cartArr.length-1){
	cartArr.price}*/
}