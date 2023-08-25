import { createContext, useState } from "react";
import PropTypes from "prop-types";
import { useEffect } from "react";

export const UserContext = createContext()

export const UserProvider = ({ children }) => {
    
    const [user, setUser] = useState({});
    const [userCart, setUserCart] = useState([]);

    const addToCart =  (product) =>{
        setUserCart((prevCart) => [...prevCart, product])
    }

    const removeFromCart = (productIdToRemove) => {
        setUserCart((prevCart) => prevCart.filter(product => product.id !== productIdToRemove));
      }

    useEffect(() => {
        const savedCart = localStorage.getItem("userCart");
        if (savedCart) {
            setUserCart(JSON.parse(savedCart));
        }
    }, []);

    useEffect(() => {
        localStorage.setItem("userCart", JSON.stringify(userCart));
    }, [userCart]);

    return (
        <UserContext.Provider value={{user, setUser, userCart, addToCart, removeFromCart}}>
            {children}
        </UserContext.Provider>
    );
}

UserProvider.propTypes = {
    children: PropTypes.node.isRequired,
};