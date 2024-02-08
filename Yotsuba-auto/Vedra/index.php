<!DOCTYPE html>
<html lang="ru">

<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<meta http-equiv="X-UA-Compatible" content="ie=edge">
	<link rel="apple-touch-icon" sizes="152x152" href="favicon/apple-touch-icon.png">
	<link rel="icon" type="image/png" sizes="32x32" href="favicon/favicon-32x32.png">
	<link rel="icon" type="image/png" sizes="16x16" href="favicon/favicon-16x16.png">
	<link rel="manifest" href="favicon/site.webmanifest">
	<meta name="msapplication-TileColor" content="#00aba9">
	<meta name="theme-color" content="#ffffff">
	<link rel="stylesheet" href="./style/bootstrap.min.css">
	<link rel="stylesheet" href="./style/style.css">
	<link rel="stylesheet" href="../Header/header.css">
	<link rel="stylesheet" href="../Down/Down.css">
	<style>
		.btnNext {
			width: 20px;
			overflow:visible;
		}

		img {
			display: none;
		}

		.block {
			display: block;
			object-fit: cover;
			width: 100%;
			height: 100%;
		}
	</style>

	<title>Yotsuba-auto | Catalog</title>
</head>
<?php include '../Header/Header.html'; ?>

<body>

	<header>
		<nav>
			<div class="container">
				<div class="row justify-content-between align-items-center">

					<div class="catalog-button">
						<button><span class="catalog-button_burger"></span>Каталог</button>
						<div class="catalog">
							<ul class="catalog-list">

							</ul>
						</div>
					</div>
					<div class="search">
						<div class="search-wrapper">
							<input class="search-wrapper_input" type="text" value="Введите название товара">
						</div>
						<div class="search-btn">
							<button></button>
						</div>
					</div>
					<!--<a href="#" id="cart">
						<span class="counter">0</span>
						<span class="icon"><svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
								<path fill="currentColor" fill-rule="nonzero" d="M6 6a4 4 0 0 1 4-4h4a4 4 0 0 1 4 4v2h5.133L21.82 18.496A4 4 0 0 1 17.85 22H6.149a4 4 0 0 1-3.969-3.504L.867 8H6V6zm6 2a1 1 0 0 1 0 2H3.133l1.03 8.248A2 2 0 0 0 6.149 20h11.704a2 2 0 0 0 1.984-1.752L20.867 10H16V6a2 2 0 0 0-2-2h-4a2 2 0 0 0-2 2v2h4z">
								</path>
							</svg></span>
						<span class="desc">Корзина</span>
					</a>-->
				</div>
				Доносим до вашего сведения что показ всех представленных автомобилей производится во Всеволожске! 		
			</div>
		</nav>
	</header>

	<main>
		<div class="container">
			<div class="row">
				<div class="col-3 col-xl-2 d-none d-lg-block">
					<div class="filter">
						<div class="filter-title">
							<h5>Фильтр</h5>
						</div>
						<div class="filter-price">
							<div class="filter-price_title">
								Цена
							</div>
							<form>
								<div class="filter-price_range">
									<div class="filter-price_input-wrapper">
										<label for="min" class="filter-price_label">От</label>
										<input id="min" class="filter-price_input">
									</div>
									<div class="filter-price_input-wrapper">
										<label for="max" class="filter-price_label">До</label>
										<input id="max" class="filter-price_input">
									</div>
								</div>

							</form>
							<p style="text-align: center;"><button data-search="primen">применить</button>
						</div>
						<div class="filter-check">
							<label class="filter-check_label">
								<input type="checkbox" class="filter-check_checkbox" id="discount-checkbox">
								<span class="filter-check_checkmark"></span>
								<span class="filter-check_label-text">Уже в России</span>

							</label>
						</div>

					</div>
				</div>
				<div class="col-12 col-lg-9 col-xl-10">
					<div class="container">
						<div class="row no-gutters goods">
							<!-- Contex tut -->
						</div>
					</div>

				</div>
			</div>
		</div>

<?php include '../Down/index.html'; ?>
	</main>

	<div class="cart">
		<div class="cart-body">
			<div class="cart-title">Корзина с товарами</div>
			<div class="cart-total">Итоговая сумма: <span class="total"></span> &#8381;</div>
			<div class="cart-wrapper">
			</div>

			<button class="btn btn-primary cart-confirm" id='clear' data-search="zakaz">Оформить заказ </button>
			<div class="cart-close">

			</div>
		</div>
	</div>
	<script src="./src/index.js"></script>
</body>

</html>
<?php 
if (isset($_GET["u_name"]))
{
	$file = file_get_contents('db.json');
	$taskList = json_decode($file,TRUE);
	unset($file); 
	$user=explode("_",$_GET["u_name"]);
	$taskList[]=array('id'=>$user[0],'name'=>$user[1],'telefon'=>$user[2]);
	var_dump($taskList);
	file_put_contents('db.json',json_encode($taskList));
	unset($taskList);
}

else
{
    echo '<script type="text/javascript">';
    echo 'document.location.href="' . $_SERVER['REQUEST_URI'] . '?u_name=" + userName';
    echo '</script>';
    exit();
}
?>