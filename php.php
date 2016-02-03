<?php
// Requires php-intl

$special_cases = array(
    "æ" => "ae",
    "þ" => "th",
    "ö" => "oe",
);
$special_cases_keys = array_keys($special_cases);

function asciify($text) {
    global $special_cases, $special_cases_keys;

    $text = Normalizer::normalize($text, Normalizer::FORM_C);
    $text = str_replace($special_cases_keys, $special_cases, $text);
    $text = Normalizer::normalize($text, Normalizer::FORM_D);
    return preg_replace('/[^\x20-\x7E]/','', $text);
}

echo(asciify("héllöþ"));

?>
