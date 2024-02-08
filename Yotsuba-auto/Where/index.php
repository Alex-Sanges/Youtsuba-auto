<!DOCTYPE html>
<html lang="ru">

<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<meta http-equiv="X-UA-Compatible" content="ie=edge">
	<link rel="apple-touch-icon" sizes="152x152" href="../favicon/apple-touch-icon.png">
	<link rel="icon" type="image/png" sizes="32x32" href="../favicon/favicon-32x32.png">
	<link rel="icon" type="image/png" sizes="16x16" href="../favicon/favicon-16x16.png">
	<link rel="manifest" href="../favicon/site.webmanifest">
	<meta name="msapplication-TileColor" content="#00aba9">
	<meta name="theme-color" content="#ffffff">
	<link rel="stylesheet" href="../style/style.css">
	<link href="../style/Styl.css" rel="stylesheet" type="text/css">
	<link rel="stylesheet" href="./style.css">
	<link rel="stylesheet" href="../Shrifts/Shrifts.css">
	<link rel="stylesheet" href="../Down/Down.css">
	<title>Yotsuba-auto | Where</title>
</head>
<?php include '../Header/Header.html'; ?>

<body>
<?php include '../Left-Banners/Banners.html';?>
<span class="Middle">
<div class="vertical">
<div><p>Для отслеживания заказа, введите Трек-номер полученный вами во время оформления заказа.</p>
<p class="uncor" id="uncord">Заказ с таким Трек-номером не обнаружен. Убедитесь в правильности ввода и попробуйте ещё раз.</p>
<input type="text" class="vvod" size="9">
<p><input type="submit" class="b" value="Ввести" onclick="doit();"></p>
</div>
</div>
<div id="car">
<div class="vertical" id="hidden">
<div>
	<div class="vertical">
		<div class="info">Номер заказа</div>
		<div class="info" id="number">123456789</div>		
	</div>
	<div class="vertical">
		<div class="info">Автомобиль</div>
		<div class="info" id="auto">123456789</div>
	</div>
	<div class="vertical">
		<div class="info">Этап доставки</div>
		<div class="info" id="order">123456789</div>
	</div>
	<div class="vertical">
		<div class="info">Дата последнего обновления</div>
		<div class="info" id="data">123456789</div>
	</div>
	</div>
	<img src="" alt="" id="car">
</div>
</div>
	
					<div class="none">
						<div class="row no-gutters goods">
						
							<!-- Contex tut -->
						</div>
					</div>
					
		
		<script src="./src/index.js"></script>
</span>
		<?php include '../Right-Banners/Banners.html';?>
			</span>
		</nav>
		<script src="./src/index.js"></script>
		<?php include '../Down/index.html'; ?>
</body>
</html>