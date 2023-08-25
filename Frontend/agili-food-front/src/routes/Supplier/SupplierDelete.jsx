import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import agileFoodFetch from "../../axios/config";
import { useParams } from "react-router-dom";
import './SupplierDelete.css'


const SupplierDelete = () => {

    const navigate = useNavigate();
    const { id } = useParams();
  
    const deleteSupplier = async () => {
        agileFoodFetch.delete("/Supplier/Delete", {
            data: id
        } 
        )

        navigate('/Suppliers')
    }
  
    return (
        <div className="content">
            <h1>Tem certeza de que quer deletar?</h1>
                <button className="btnDelete" onClick={() => deleteSupplier()}>SIM</button>
            <Link to={`/Suppliers`}>
                <button className="btnDelete">NÃO</button>
            </Link>
        </div>
  )
}

export default SupplierDelete