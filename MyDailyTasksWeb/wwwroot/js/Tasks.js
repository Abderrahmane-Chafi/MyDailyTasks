// Event listener for the "Remove" button
$('#removeBtn').click(function () {
    var url = $(this).data('url');
    Delete(url);
});

// Function to delete the task
function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You will not be able to go back!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete!',
        cancelButtonText: 'Cancel'
    }).then((result) => {
        if (result.isConfirmed) {
            // Make an AJAX request to hit the endpoint for delete
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        location.reload(); // Reload the page
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
