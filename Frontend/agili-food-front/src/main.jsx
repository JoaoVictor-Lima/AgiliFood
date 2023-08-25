import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'

import {createBrowserRouter, RouterProvider} from 'react-router-dom'

//paginas
import Home from './routes/Home.jsx'
import Suppliers from './routes/Supplier/Suppliers.jsx'
import NewSupplier from './routes/Supplier/NewSupplier.jsx'
import SupplierDelete from './routes/Supplier/SupplierDelete.jsx'
import SupplierEdit from './routes/Supplier/SupplierEdit.jsx'
import NewCollaborator from './routes/Collaborator/NewCollaborator.jsx'
import Store from './routes/Store/Store.jsx'
import NewProducts from './routes/Products/NewProducts.jsx'
import Products from './routes/Products/Products.jsx'
import DeleteProduct from './routes/Products/DeleteProduct.jsx'
import EditProduct from './routes/Products/EditProduct.jsx'
import Cart from './routes/Store/Cart.jsx'
import Collaborators from './routes/Collaborator/Collaborators.jsx'
import CollaboratorOrders from './routes/Collaborator/CollaboratorOrders.jsx'

import './index.css'

const router = createBrowserRouter([
  {
    element: <App/>,
    children: [
      {
        path: "/",
        element: <Home/>,
      },
      {
        path: "/Suppliers",
        element: <Suppliers/>
      },
      {
        path: "/NewSupplier",
        element: <NewSupplier/>
      },
      {
        path: "/SupplierDelete/:id",
        element: <SupplierDelete/>
      },
      {
        path: "/SupplierEdit/:id/:_restaurantName/:isActive",
        element: <SupplierEdit/>
      },
      {
        path: `/Collaborators`,
        element: <Collaborators/>
      },
      {
        path: "/NewCollaborator",
        element: <NewCollaborator/>
      },
      {
        path: `/CollaboratorOrders/:id`,
        element: <CollaboratorOrders/>
      },
      {
        path:  "/Store",
        element: <Store/>
      },
      {
        path: "/Products/:id",
        element: <Products/>
      },
      {
        path: "/NewProduct/:supplierId",
        element: <NewProducts/>
      },
      {
        path: "/DeleteProduct/:id/:supplierId",
        element: <DeleteProduct/>
      },
      {
        path: "/EditProduct/:id/:supplierId",
        element: <EditProduct/>
      },
      {
        path: "/Cart",
        element: <Cart/>
      }
    ]
  }
])

import { UserProvider } from './routes/Context/UserContext.jsx'

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <UserProvider>
       <RouterProvider router={router}/>
    </UserProvider>
  </React.StrictMode>,
)
