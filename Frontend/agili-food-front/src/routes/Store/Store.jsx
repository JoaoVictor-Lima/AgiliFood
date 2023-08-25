import agileFoodFetch from '../../axios/config';
import { useState, useEffect } from 'react';
import { useContext } from 'react';
import { UserContext } from '../Context/UserContext';
import { Link } from 'react-router-dom';

import './Store.css'

const Store = () => {
    const [suppliers, setSuppliers] = useState([])
    const [productsBySupplier, setProductsBySupplier] = useState({});
    const {userCart, addToCart} = useContext(UserContext); 

    const getSuppliers = async () => {
        try {
            const response = await agileFoodFetch.get("Supplier/GetAll")
            const data = response.data;

            setSuppliers(data)
        } catch (error) {
            console.log(error)
        }
    }

    const getProducts = async(supplierId) => {
        try {
            const response = await agileFoodFetch.get(`/Product/GetBySupplierId?id=${supplierId}`);
            const data = response.data;

            setProductsBySupplier(prevState => ({
                ...prevState,
                [supplierId]: data
            }));
    
        } catch (error) {
            console.log(error)
        }

    }

    const formatPrice = (price) =>{
        return price.toLocaleString('pt-BR', {
          style: 'currency',
          currency: 'BRL',
          minimumFractionDigits: 2
        })
    }

    const addProductToCart = async(e, product) => {
        e.preventDefault()
        await addToCart(product)
        await console.log(userCart)
    }

    useEffect(() => {
        getSuppliers();
    }, [])

    useEffect(() => {
        suppliers.forEach(supplier => {
            getProducts(supplier.id);
        });
    }, [suppliers]);

return (
    <div className='StoreContent'>
        <div className='Restaurants'>
            <h2>Restaurantes</h2>
            {suppliers.length === 0 ? <p>Carregando...</p> : (
                suppliers
                .filter((supplier) => supplier.isActive)
                .map((supplier) => (
                    <div key={supplier.id} className='Restaurant'>
                        <h3>{supplier.restaurantName}</h3>
                        <div className='Products'>
                            {productsBySupplier[supplier.id] ? (
                                productsBySupplier[supplier.id].length === 0 ? (
                                    <p>Sem produtos</p>
                                ) : (
                                    productsBySupplier[supplier.id].map((product) => (
                                        <div className='Product' key={product.id}>
                                            <div className='Description'>
                                                <p>{product.name}</p>
                                                <p>{formatPrice(product.price)}</p>
                                            </div>
                                            <div className='button-add'>
                                                <button onClick={(e) => addProductToCart(e, product)} className='btn'>Add ao carrinho</button>
                                            </div>
                                        </div>
                                    ))
                                )
                            ) : (
                                <p>Carregando produtos...</p>
                            )}
                        </div>
                    </div>
                ))
            )}
        </div>
        <div>
            {userCart.length === 0 ? <Link className='float-btn' to={`/Cart`}>Carrinho de compras</Link> : <Link className='float-btn' to={`/Cart`}>Carrinho de compras <p>{userCart.length}</p></Link>}
        </div>
    </div>
  )
}

export default Store