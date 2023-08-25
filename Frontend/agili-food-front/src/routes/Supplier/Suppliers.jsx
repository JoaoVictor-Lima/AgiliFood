import { useState, useEffect } from "react"
import { Link } from "react-router-dom"
import agileFoodFetch from "../../axios/config";
import "./Supplier.css"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEdit, faTimes } from '@fortawesome/free-solid-svg-icons';

//images
import notActive from '../../image/121.png'
import actived from '../../image/2346.png'

const Suppliers = () => {
    const [suppliers, setSupplieres] = useState([])

    const getSuppliers = async() => {
        try {
            const response = await agileFoodFetch.get("/Supplier/GetAll")
            
            const data = response.data;

            setSupplieres(data);
        } catch (error) {
            console.log(error)
        }
    }

    const activeChange = async (id, restaurantName, isActive) => {
        const supplierUpdate = { id, restaurantName, isActive };
        try {
          await agileFoodFetch.put("/Supplier/Update", supplierUpdate);
          getSuppliers();
        } catch (error) {
          console.error("Erro ao atualizar status:", error);
        }
    };
    
  
    useEffect(() => {
        getSuppliers();
      }, []);
  
    return (
        <div className="supplier">
            <h1>Todos os fornecedores</h1>
            <div className="content">
                <div>   
                    <div className="temp">
                        <h2>FORNECEDORES</h2>
                        <h2>ATIVOS</h2>
                    </div>
                    {suppliers.length === 0 ? <p>Carregando...</p> : (
                        suppliers.map((supplier) => (
                        <div className='supplier-list' key={supplier.id}>
                            <div className="temp">
                            <h2>{supplier.restaurantName}</h2>
                            <button
                                onClick={() => activeChange(supplier.id, supplier.restaurantName, !supplier.isActive)}
                                style={{ backgroundColor: "inherit", border: "none", width: "6rem" }}
                            >
                                {supplier.isActive ? (
                                <img src={actived} alt="Ativo" style={{ width: "40px", height: "40px" }} />
                                ) : (
                                <img src={notActive} alt="Desativado" style={{ width: "40px", height: "40px" }} />
                                )}
                            </button>
                                </div>
                                <div>
                                    <Link to={`/Products/${supplier.id}`}><button className="btn">Produtos</button></Link>
                                    <Link to={`/SupplierEdit/${supplier.id}/${supplier.restaurantName}/${supplier.isActive}`}><button className="btn"><FontAwesomeIcon icon={faEdit} /></button></Link>
                                    <Link to={`/SupplierDelete/${supplier.id}`}><button className="btn"><FontAwesomeIcon icon={faTimes} /></button></Link>
                                </div>
                            </div>
                        ))
                    )}
                </div>             
            </div>
            <div className="btn float-btn"><Link to={`/NewSupplier`}>Adicionar Fornecedor</Link></div>
        </div>
        
  );
};

export default Suppliers