<?php

// config
$agent = "test-upload";
$key = "TEST";
$img_dir = "temp/img/";
$url = "http://".$_SERVER['SERVER_NAME']."/temp/img/";
// end

if ($_SERVER['HTTP_USER_AGENT']!=$agent || $_GET['key']!=$key) die();

$loc = array(
	"en"=>array(
		"upload_err"=>"File upload error, too large or server error.",
		"write_err"=>"File write error.",
		"format_err"=>"Incorrect image format.",
		"file_err"=>"Image corrupted."
	),
	"ru"=>array(
		"upload_err"=>"Ошибка загрузки файла, слишком большой размер или ошибка сервера.",
		"write_err"=>"Ошибка записи файла.",
		"format_err"=>"Неверный формат изображения.",
		"file_err"=>"Изображение повреждено.",
	),
);

$curlang = (isset($_POST['lang']) && isset($loc[$_POST['lang']]) ? $_POST['lang'] : "en");

function GetMessage($key) {
	global $loc,$curlang;
   	return (isset($loc[$curlang][$key])?$loc[$curlang][$key]:$key);
}

if (!isset($_POST["image"])) {
	die(GetMessage("upload_err"));
}

if (!function_exists('getimagesizefromstring')) {
      function getimagesizefromstring($string_data)
      {
         $uri = 'data://application/octet-stream;base64,'.base64_encode($string_data);
         return getimagesize($uri);
      }
}

$id = base_convert(time(), 10, 36);

$file = base64_decode($_POST["image"]);

if (!$file) die(GetMessage("file_err"));

$arr = array("image/png"=>"png","image/jpeg"=>"jpg","image/gif"=>"gif","image/x-ms-bmp"=>"bmp");

$tmp = getimagesizefromstring($file);

if (!$tmp) die(GetMessage("file_err"));

if (!array_key_exists($tmp["mime"],$arr)) die(GetMessage("format_err"));

$name = $img_dir.$id;
$ext = ".".$arr[$tmp["mime"]];
// small fix, maybe not very good but works
if (file_exists($name.$ext)) {
	$i = 0;
	$oname = $name;
	while(file_exists($name.$ext)) {
		$i++;
		$name = $oname.base_convert($i,10,36);
	}
	$id = $id.base_convert($i,10,36);
}

if (file_put_contents($name.$ext,$file)) {
	echo $url.$id.$ext;
} else {
	echo GetMessage("write_err");
}

?>