using LekoShop.Models;

namespace LekoShop.Services.Interfaces
{
    public interface ICart
    {
        List<Cart>? ViewCartList();
        Cart? ViewCartById(int CartId);
        Cart? CreateNewCart(Cart cart);
        Cart? DeleteCart();
        Cart? DeleteCartById(int cartId);
        Cart? UpdateCart(Cart cart);

    }
}
