import {applyMiddleware, combineReducers, compose, createStore} from 'redux';
import thunk from 'redux-thunk';
import itemReducer from '../reducers/item'

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

export default () => {
    const store = createStore(
        combineReducers({
            item: itemReducer
        }),
        composeEnhancers(applyMiddleware(thunk))
    );

    return store;
};