document.addEventListener('DOMContentLoaded', function () {
    const searchInput = document.getElementById('productSearchInput');

    searchInput.addEventListener('keyup', function () {
        const query = searchInput.value;

        if (query.length > 0) {
            fetchProducts(query);
        } else {
            fetchProducts('');  // fetch all products if the search input is cleared
        }
    });
});

// function for getting products asyncronously : 
function fetchProducts(searchTerm) {
    const currentCategory = '@Model.CurrentCategory';  // passing the current category from the view
    const currentPage = '@Model.CurrentPage';  // passing the current page from the view

    fetch(`/Product/SearchProducts?searchTerm=${searchTerm}&category=${currentCategory}&page=${currentPage}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.text())
        .then(data => {
            document.getElementById('productList').innerHTML = data;
        })
        .catch(error => console.error('Error fetching products:', error));
}
