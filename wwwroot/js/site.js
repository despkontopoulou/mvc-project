﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//hide notification
function handleNotification() {
    if (showMessage === 'true') {
        setTimeout(function () {
            $(".alert").alert('close');
        }, 5000);
    }
}

// Call the function to handle the notification behavior
handleNotification();