import React,{ useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/portfolio";
import PortfolioForm from "./PortfolioForm";
import ModalAdd from "./ModalAdd";
import {Table, Grid,Paper, TableContainer, TableHead, TableRow, TableCell, TableBody, InputLabel, Select, MenuItem } from "@material-ui/core";

const Portfolios = (props) => {
    
    
    useEffect(() => {
        props.fetchAllPortfolios()
    }, [])
    const [portfolioId, setPortfolioId] = useState(0);

var handleChange = event => {
    let { name, value } = event.target;
    setPortfolioId(value);
  }
  
    return (
        
        <Paper>
<InputLabel id="label">Портфель</InputLabel>
<Select style={{width:"200px"}} name="portfolioId" onChange={handleChange}  labelId="label" id="select" value={portfolioId}>
        {props.portfolioList.map((record,index) => (
                      <MenuItem key={record.portfolioId} value={record.portfolioId}>
                        {record.portfolioName}
                      </MenuItem>
                    ))}
</Select>
<ModalAdd></ModalAdd>



    <Grid container>
            <Grid item xs={1}>       
            <PortfolioForm/>
            </Grid>
            <Grid item xs={12}>       
            <TableContainer>
                <Table>
                    <TableHead>
                        <TableRow>
                             <TableCell>Название</TableCell>
                            <TableCell>Начальная стоимость</TableCell>
                            <TableCell>Количество</TableCell>
                            <TableCell>Дата первой  покупки</TableCell>
                            <TableCell>Цена сейчас</TableCell>
                            <TableCell>Общая стоимость закупки</TableCell>
                            <TableCell>Общая стоимость сейчас</TableCell>
                        </TableRow>
                     </TableHead>
                     <TableBody>
                        {
                             props.portfolioList.map((record,index)=>{
                                 return (
                                <TableRow key={index}>
                                    <TableCell>{record.portfolioName}</TableCell>

                                </TableRow>)
                                 })
                         }
                     </TableBody>
                     
                </Table>
                
            </TableContainer>
            </Grid>
        </Grid>
        
</Paper>)
}
const mapStateToProps = state => ({
    portfolioList: state.portfolio.list
})


const mapActionToProps ={
    fetchAllPortfolios: actions.fetchAll
}

export default connect(mapStateToProps, mapActionToProps)(Portfolios);