window.showSwal = function(type, message) {
    if(type == "success") {
        Swal.fire({
            title: "Good job!",
            text: "You clicked the button!",
            icon: "success"
        });
    }
    if(type == "error") {
        Swal.fire({
            title: "Failed!",
            text: "Something went wrong",
            icon: "error"
        });
    }

}