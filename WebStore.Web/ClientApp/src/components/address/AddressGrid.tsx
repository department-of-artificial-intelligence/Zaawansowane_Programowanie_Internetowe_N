import React, { useContext, useEffect, useState } from 'react';
import { DataGrid, GridColDef, GridRenderCellParams } from '@mui/x-data-grid';
import { IAddress } from '../../models/IAddress';
import { Link } from 'react-router-dom';
import AddressContext from '../../contexts/AddressContext'
type IState = {
    addresses: IAddress[];
}
export const AddressGrid = () => {
    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 50 },
        { field: 'city', headerName: 'City', width: 130 },
        { field: 'zipCode', headerName: 'ZipCode', width: 130 },
        { field: 'street', headerName: 'Street', width: 150 },
        { field: 'country', headerName: 'Country', width: 100 },
        {
            field: 'buildingNumber',
            headerName: 'Building number',
            type: 'number',
            width: 130,
        },
        {
            field: 'apartmentNumber',
            headerName: 'Apartment number',
            type: 'number',
            width: 150,
        },
        {
            field: "edit",
            headerName: "Edit",
            sortable: false,
            renderCell: (params: GridRenderCellParams) => {
                const address: IAddress = params.row;
                return <Link to={`/address/edit/${address.id}`} className="btn btn-primary" >Edit</Link>
            }
        },
        {
            field: "delete",
            headerName: "Delete",
            sortable: false,
            renderCell: (params: GridRenderCellParams) => {
                const address: IAddress = params.row;
                return <Link to={`/address/delete/${address.id}`} className="btn btn-primary">Delete</Link>
            }
        },
    ]
    const { getAddresses, state }: any = useContext(AddressContext);
    useEffect(() => {
        getAddresses();
    }, []);
    return (
        <div>
            <Link style={{ marginBottom: "5px" }} to={`/address/add`} className="btn btn-primary">Add</Link>
            <div className="address-grid">
                <div style={{ height: 400, width: '100%' }}>
                    <DataGrid
                        rows={state.addresses}
                        columns={columns}
                        //pageSize={5}
                        //rowsPerPageOptions={[5]}
                        checkboxSelection
                    />
                </div>
            </div>
        </div>
    )
}
