import React, { useEffect, useState } from "react";
import { IAddress } from "../../models/IAddress";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import SaveIcon from "@mui/icons-material/Save";
import CancelIcon from "@mui/icons-material/Cancel";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import { CardHeader } from "@mui/material";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";
type IProps = {
  labelName: string;
};
export const AddressAddOrEditForm = (props: IProps) => {
  const navigate = useNavigate();
  const params = useParams();
  const [state, setState] = useState<IAddress>({
    id: 0,
    buildingNumber: 0,
    city: "",
    country: "",
    street: "",
    zipCode: "",
    apartmentNumber: 0,
  });
  useEffect(() => {
    const id: number | undefined = params["id"]
      ? parseInt(params["id"])
      : undefined;
    if (id !== undefined) {
      const getAddress = async () => {
        const response = await axios.get<IAddress>(`/api/Address/${id}`);
        if (response.status == 200) setState({ ...response.data });
      };
      getAddress();
    }
  }, []);
  const onInputTextChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const name = e.target.name as keyof typeof state;
    setState((state) => ({ ...state, [name]: e.target.value }));
  };
  const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const response = await axios.post<IAddress>("/api/Address", state);
    if (response.status == 200)
      setState({
        id: 0,
        buildingNumber: 0,
        city: "",
        country: "",
        street: "",
        zipCode: "",
        apartmentNumber: 0,
      });
    navigate("/address");
  };
  const onCancel = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    navigate("/address");
  };
  return (
    <div className="form-container">
      <Box
        component="form"
        sx={{
          ".MuiTextField-root": { m: 1, width: "25ch" },
        }}
        noValidate
        autoComplete="off"
        onSubmit={onSubmit}
      >
        <Card>
          <CardHeader title={props.labelName}></CardHeader>
          <CardContent>
            <div>
              <input type="hidden" value={state.id} />
              <TextField
                required
                onChange={onInputTextChange}
                label="City"
                name="city"
                value={state.city}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="Zip code"
                name="zipCode"
                value={state.zipCode}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="Street"
                name="street"
                value={state.street}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="Country"
                name="country"
                value={state.country}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="Building number"
                name="buildingNumber"
                type="number"
                value={state.buildingNumber}
                InputLabelProps={{
                  shrink: true,
                }}
              />
              <TextField
                required
                onChange={onInputTextChange}
                label="Apartment number"
                name="apartmentNumber"
                type="number"
                value={state.apartmentNumber}
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </div>
            <hr />
          </CardContent>
          <CardActions>
            <Button type="submit" variant="contained" endIcon={<SaveIcon />}>
              {" "}
              Save{" "}
            </Button>
            <Button
              type="button"
              variant="contained"
              onClick={onCancel}
              endIcon={<CancelIcon />}
            >
              {" "}
              Cancel
            </Button>
          </CardActions>
        </Card>
      </Box>
    </div>
  );
};
