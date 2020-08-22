import React,{ useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/portfolio";

const Portfolios = (props) => {
    
    
    useEffect(() => {
        props.fetchAllPortfolios()
    }, [])

    return (<div>from Portfolios</div>);
}

const mapStateToProps = state=>({
        portfolioList:state.portfolio.list
})

const mapActionToProps ={
    fetchAllPortfolios: actions.fetchAll
}

export default connect(mapStateToProps, mapActionToProps)(Portfolios);