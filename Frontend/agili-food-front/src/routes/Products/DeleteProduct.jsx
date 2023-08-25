import { Link, useNavigate, useParams } from "react-router-dom"
import agileFoodFetch from './../../axios/config';
import { useEffect, useState } from "react";

const DeleteProduct = () => {

    const navigate = useNavigate();

    const { id } = useParams();
    const { supplierId } = useParams();
    const [product, setProduct] = useState([]);

    const deleteProduct = async () => {
        console.log(id)
        await agileFoodFetch.delete(`/Product/Delete?id=${id}`)

        navigate(`/Products/${supplierId}`)
    }

    useEffect(() => {
        const getProduct = async() => {
            const response = await agileFoodFetch.get(`/Product/GetById?id=${id}`)
            const data = response.data;
    
            setProduct(data);
        };
        getProduct();
    }, [ id ])
  return (
    <div className="content">
        <h1>Tem certeza de que quer deletar o produto: {product.name}?</h1>
            <button className="btnDelete" onClick={() => deleteProduct()}>SIM</button>
        <Link to={`/Products/${supplierId}`}>
            <button className="btnDelete">NÃO</button>
        </Link>
    </div>
  )
}

export default DeleteProduct