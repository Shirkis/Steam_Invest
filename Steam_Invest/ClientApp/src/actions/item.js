import axios from "axios";
const backendUrl = "https://localhost:44326";

export const getItemsForPortfolio = () => dispatch => {
    axios.get(`${backendUrl}/api/portfolio/4/items`)
        .then(response => {
          dispatch({ type: 'FETCH_ITEMS_SUCCESS', data: response.data });
      })
        .catch(err => console.log(err))
  }

  export const postItem = (item) => dispatch => {
    dispatch({ type: 'POST_ITEM_START' });
    axios.post(`${backendUrl}/api/item`, item)
        .then(response => {
          dispatch({ type: 'POST_ITEM_SUCCESS', data: response.data });
          dispatch(getItemsForPortfolio());
      })
      .catch(err => {
        dispatch({ type: 'API_ACTION_ERROR', data: err });
      })
  }
  
  export const putItem = (itemId, item) => dispatch => {
    dispatch({ type: 'PUT_ITEM_START' });
    axios.put(`${backendUrl}/api/item/${itemId}`, item)
        .then(response => {
          dispatch({ type: 'PUT_ITEM_SUCCESS', data: response.data });
          dispatch(getItemsForPortfolio());
      })
      .catch(err => {
        dispatch({ type: 'API_ACTION_ERROR', data: err });
      })
  }
  
  export const deleteItem = (itemId) => dispatch => {
    dispatch({ type: 'DELETE_ITEM_START' });
    axios.delete(`${backendUrl}/api/item/${itemId}`)
        .then(response => {
          dispatch({ type: 'DELETE_ITEM_SUCCESS', data: response.data });
          dispatch(getItemsForPortfolio());
      })
      .catch(err => {
        dispatch({ type: 'API_ACTION_ERROR', data: err });
      })
  }

  export const setItem = (item) => dispatch => {
    dispatch({ type: 'SET_ITEM', data: item});
  }