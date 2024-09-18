document.querySelectorAll('.add-to-cart').forEach(button => {
    button.addEventListener('click', async (event) => {
        event.preventDefault(); // Prevent default form submission or link behavior

        const productId = event.target.dataset.productId;
        const quantityInput = document.getElementById(`quantity-${productId}`);
        const quantity = parseInt(quantityInput.value, 10); // Convert quantity to an integer

        const response = await fetch(`/Cart/AddToCart`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ productId, quantity }) // Send quantity as an integer
        });

        if (response.ok) {
            const cart = await response.json();
            if (cart.updated) {
                alert('Product quantity updated in cart');
            } else {
                alert('Product added to cart');
            }
        } else {
            alert('Failed to add product to cart');
        }
    });
});

document.addEventListener("DOMContentLoaded", () => {
    const removeButtons = document.querySelectorAll(".remove-from-cart");
    removeButtons.forEach((button) => {
        button.addEventListener("click", async (event) => {
            event.preventDefault();
            const productId = event.target.closest("tr").dataset.productId;
            const response = await fetch(`/cart/remove?productId=${productId}`, {
                method: "POST"
            });
            if (response.ok) {
                // Refresh the page or update the DOM dynamically
                location.reload();
            } else {
                alert("Failed to remove product from cart.");
            }
        });
    });
});
