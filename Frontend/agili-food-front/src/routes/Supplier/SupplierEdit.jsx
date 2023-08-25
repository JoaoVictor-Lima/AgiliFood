import agileFoodFetch from "../../axios/config";
import { useParams } from "react-router-dom";
import './SupplierEdit.css'
import { useState } from "react";
import { useNavigate } from 'react-router-dom';

const SupplierEdit = () => {

    const [restaurantName, setRestaurantName] = useState();

    const navigate = useNavigate();
    const { id } = useParams();
    const { _restaurantName } = useParams();
    const { isActive } = useParams();
    const supplierUpdated= {id: parseInt(id), restaurantName, isActive: isActive === 'true' ? true : false}

    const updateSupplier = async (e) =>{
        e.preventDefault();

        await agileFoodFetch.put("/Supplier/Update", 
            supplierUpdated)

         navigate('/Suppliers');
    }

  return (
    <div className="edit-content">
      <form onSubmit={(e) => updateSupplier(e)}>
          <div className="edit-head">
            <h2>Insira um novo nome</h2>
            <input 
                type="text" 
                placeholder={_restaurantName}
                name="restaurantName"
                id="restaurantName"
                onChange={(e) => setRestaurantName(e.target.value)}
                />
            </div>
          <input className="btn" type="submit" value="Enviar"/>
      </form>
    </div>
  )
}

export default SupplierEdit