////////////////////////////////////////////////////////////////////////////

//Shoppingcart open & close

const cartOpenA = document.getElementById('a-cart-open');
const cartOpenLi = document.getElementById('li-cart-open');
const cartCloseX = document.getElementById('cart-close');

const cart = document.querySelector('.cart-wrap');

function showCart() {
    cart.style.display = 'grid';
}

function closeCart() {
    cart.style.display = 'none';
}



cartOpenA.addEventListener('click', showCart);
cartOpenLi.addEventListener('click', showCart);
cartCloseX.addEventListener('click', closeCart);


////////////////////////////////////////////////////////////////////////////
//Add to cart
function addToCart(id) {
    const url = '/AddToCart?productId=' + id;
    window.location.href = url;
}


////////////////////////////////////////////////////////////////////////////
//Add to cart on background /w jquery ajax
function editCartAjax(id, action) {
    // Make AJAX request to add product to cart
    $.ajax({
        url: '/AddToCart?productId=' + id + '&action=' + action,
        type: 'GET',
        success: function (result) {
            // Handle success response
            console.log(result);
            updateCart(result);
            showCart();
        },
        error: function (xhr, status, error) {
            // Handle error response
            console.log(xhr.responseText);
        }
    });
}

////////////////////////////////////////////////////////////////////////////
function updateCart(jsonString) {
    //Parse the JSON string into JavaScript object
    const updatedCart = JSON.parse(jsonString);

    //Get cart content container
    const cartContentContainer = document.querySelector('.cart-content-container');

    //Remove all existing cart contents
    cartContentContainer.innerHTML = '';

    //Price values
    let subTotal = 0;

    //Loop through the updated cart items and add them to the cart content container
    for (const itemId in updatedCart._items) {
        const item = updatedCart._items[itemId];

        subTotal += item.Product.Price * item.Quantity

        const cartContent = document.createElement('div');
        cartContent.classList.add('cart-content');

        const productImage = document.createElement('img');
        productImage.src = item.Product.ImageUrl;
        productImage.alt = item.Product.Name;
        cartContent.appendChild(productImage);

        const contentInfo = document.createElement('div');
        contentInfo.classList.add('content-info');

        const productName = document.createElement('h4');
        productName.textContent = item.Product.Name;
        contentInfo.appendChild(productName);

        const productPrice = document.createElement('h3');
        productPrice.textContent = '€' + item.Product.Price.toFixed(2);
        contentInfo.appendChild(productPrice);

        cartContent.appendChild(contentInfo);

        const contentQuantity = document.createElement('div');
        contentQuantity.classList.add('content-quantity');

        const quantityIncreaseBtn = document.createElement('button');
        quantityIncreaseBtn.textContent = '+';
        quantityIncreaseBtn.addEventListener('click', function () {
            editCartAjax(item.Product.Id, 'add');
        });
        contentQuantity.appendChild(quantityIncreaseBtn);

        const quantityDisplay = document.createElement('h2');
        quantityDisplay.style.textAlign = 'center';
        quantityDisplay.style.margin = '10px';
        quantityDisplay.textContent = item.Quantity;
        contentQuantity.appendChild(quantityDisplay);

        const quantityDecreaseBtn = document.createElement('button');
        quantityDecreaseBtn.textContent = '-';
        quantityDecreaseBtn.addEventListener('click', function () {
            editCartAjax(item.Product.Id, 'remove');
        });
        contentQuantity.appendChild(quantityDecreaseBtn);

        cartContent.appendChild(contentQuantity);

        cartContentContainer.appendChild(cartContent);
    }

    //subtotal
    const myHeading = document.getElementById("subtotal");
    myHeading.textContent = "€" + subTotal;
}

