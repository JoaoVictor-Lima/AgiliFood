import { useContext } from "react"
import { UserContext } from "../Context/UserContext"
import agileFoodFetch from './../../axios/config';

import './Cart.css'

const Cart = () => {
  const {user, userCart, removeFromCart} = useContext(UserContext);  

  const createOrder = async(e) => {
    e.preventDefault();
    const id = 0; 
    const datePurchase = new Date().toISOString();
    const totalValue = 0;
    const collaboratorId = user.id;
    const newOrder = {id, datePurchase, totalValue, collaboratorId}
    
    const response = await agileFoodFetch.post(`/Order/Create`, newOrder )
    const data = response.data
    console.log("Pedido criado: ", data)

    await addProductsToOrder(data);
  }

  const addProductsToOrder = async(data) => {
    await agileFoodFetch.post(`/Order/AddProductsToOrder?orderId=${data.id}`, userCart)
  }

  const removeProductFromCart = async(productId) => {
    await removeFromCart(productId)
  }

  const formatPrice = (price) =>{
    return price.toLocaleString('pt-BR', {
      style: 'currency',
      currency: 'BRL',
      minimumFractionDigits: 2
    })
}

  return (
    <div className="CartContent">
      <div>
        {userCart.map((product) => (
            <div key={product.id} className="CartProducts">
                <div className="CartProductDescription">
                  <h3>{product.name}</h3>
                  <p>{product.description}</p>
                  <p>{formatPrice(product.price)}</p>
                </div>
                <div className="ProductButtons">
                  <button className="btn" onClick={() => removeProductFromCart(product.id)}>Remover Produto</button>
                </div>
            </div>
          ))}
      </div>
        <button onClick={(e) => createOrder(e)}>Finalizar Pedido</button>
    </div>
  )
}


export default Cart