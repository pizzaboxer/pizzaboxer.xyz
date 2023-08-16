// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

import 'flowbite';

// image preloading - thanks kjf :D

window.onload = function () {
    document.getElementById("bg_image").classList.toggle('bg-hidden');
}