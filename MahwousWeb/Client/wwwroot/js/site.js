


function CustomConfirm(title, message, type) {
    return new Promise((resolve) => {
        Swal.fire({
            title: title,
            text: message,
            type: type,
            showCancelButton: true,
            confirmButtonColor: '#d9534f',
            cancelButtonColor: '#5bc0de',
            confirmButtonText: 'تأكيد',
            cancelButtonText: 'إلغاء'
        }).then((result) => {
            if (result.value) {
                resolve(true);

                Swal.fire({
                    text: 'تمت العملية بنجاح',
                    type: 'success'
                })

            } else {
                resolve(false);
            }
        });
    });
}

function helloworld() {
    alert("hello world!");
}


function AddScriptsToThePage() {
    addScript("AdminLTE/plugins/jquery/jquery.min.js");
    addScript("AdminLTE/plugins/bootstrap/js/bootstrap.bundle.min.js");
    addScript("https://cdn.rtlcss.com/bootstrap/v4.2.1/js/bootstrap.min.js");
    addScript("AdminLTE/dist/js/adminlte.js");
}


function AddLibrariesScripts() {
    addScript("AdminLTE/plugins/jquery-ui/jquery-ui.min.js");    
    addScript("AdminLTE/plugins/chart.js/Chart.min.js");
    addScript("AdminLTE/plugins/sparklines/sparkline.js");
    addScript("AdminLTE/plugins/jqvmap/jquery.vmap.min.js");
    addScript("AdminLTE/plugins/jqvmap/maps/jquery.vmap.world.js");
    addScript("AdminLTE/plugins/jquery-knob/jquery.knob.min.js");
    addScript("AdminLTE/plugins/moment/moment.min.js");
    addScript("AdminLTE/plugins/daterangepicker/daterangepicker.js");
    addScript("AdminLTE/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js");
    addScript("AdminLTE/plugins/summernote/summernote-bs4.min.js");
    addScript("AdminLTE/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js");
    //addScript("AdminLTE/plugins/ekko-lightbox/ekko-lightbox.min.js");
    //addScript("AdminLTE/plugins/filterizr/jquery.filterizr.min.js");
    addScript("AdminLTE/dist/js/pages/dashboard.js");
    addScript("AdminLTE/dist/js/demo.js");

}


function addScript(src) {
    var s = document.createElement('script');
    s.setAttribute('src', src);
    document.body.appendChild(s);
}

