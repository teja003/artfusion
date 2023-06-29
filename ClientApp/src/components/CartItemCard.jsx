import React, {useContext, useState} from 'react'
import {authContext} from "./../context/authContext";
import {appContext} from "./../context/appContext";

function CartItemCard({id, name, price, image}) {
  const {userData} = useContext(authContext)
  const {setCartItemsCount, cartItemsCount} = useContext(appContext)
  const [removed, setRemoved] = useState(false)
  async function removeFromCart() {
    let response = await fetch(`api/ShoppingCartItem/${userData.id}/${id}`,{
      method:"DELETE",
      headers: {
                'Authorization':`Bearer ${localStorage.getItem("authToken")}`,
              }
    });
        if(response.status===204){
          console.log("removed");
            setRemoved(true);
            setCartItemsCount(prev => prev-1)
    }
  }
  return (
    <div className={removed ?"hidden" :"grid grid-cols-5 items-center justify-between w-full py-3 px-2"}>
        <div className="flex items-center justify-center max-w-[7rem] h-24">
            <img src={image} alt={name} className="h-full w-full rounded-sm "/>
        </div>
        <h4 className="text-gray-600">{name}</h4>
        <h3>₹{' '}{price}</h3>
        <div>
            <button type="button" className="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 mr-2 dark:bg-blue-600 dark:hover:bg-blue-700 focus:outline-none dark:focus:ring-blue-800">Like</button>
        </div>
        <div>
            <button onClick={removeFromCart} type="button" className="text-white bg-red-500 hover:bg-red-600 focus:ring-4 focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 mr-2 dark:bg-blue-600 dark:hover:bg-red-700 focus:outline-none dark:focus:ring-blue-800">Remove</button>
        </div>
    </div>
  )
}

export default CartItemCard