import { useParams } from 'react-router-dom';
import agileFoodFetch from '../../axios/config';
import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

const Products = () => {

    const [products, setProducts] = useState([]);

    const { id } = useParams()


    const formatPrice = (price) =>{
        return price.toLocaleString('pt-BR', {
          style: 'currency',
          currency: 'BRL',
          minimumFractionDigits: 2
        })
    }
        
    useEffect(() => {
        const getProducts = async () => {
            try {
                const response = await agileFoodFetch.get(`Product/GetBySupplierId?id=${id}`)
                const data = response.data;
                setProducts(data)
            } catch (error) {
                console.log(error)
            }
        }
        getProducts();
    }, [ id ])

  return (
    <div>
        <div>
            {products.length === 0 ? <p>Produtos não cadastrados</p> : (
                products.map((product) => (
                    <div key={product.id}>
                       <div>
                            <h2>{product.name}</h2>
                            <p>{product.description}</p>
                            <p>{formatPrice(product.price)}</p>
                        </div> 
                        <div>
                            <Link to={`/EditProduct/${product.id}/${id}`}><button className='btn'>Edit</button></Link>
                            <Link to={`/DeleteProduct/${product.id}/${id}`}><button className='btn'>Delete</button></Link>
                        </div>
                    </div>
                ))
                
            )}
        </div>
        <div className="btn float-btn"><Link to={`/NewProduct/${id}`}>Adicionar Produto</Link></div>
    </div>
  )
}

export default Products