
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


function setTitle(title) {
    document.title = title;
}

function helloworld() {
    alert("hello world!");
}

function hello(title) {
    alert(title);
}

function isScrollEnded() {

    return $(window).scrollTop() == $(document).height() - $(window).height();

}
