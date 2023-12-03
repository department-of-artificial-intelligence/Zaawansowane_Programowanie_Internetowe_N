import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { AddressGrid } from './components/Address/AddressGrid';
import { AddressAdd } from "./components/Address/AddressAdd";
import { AddressEdit } from './components/Address/AddressEdit';
import { AddressDelete } from "./components/Address/AddressDelete";
const AppRoutes = [
  {
    index: true,
    element: <AddressGrid />
  },
  {
    path: '/home',
    element: <Home />
  },
  {
    path: '/address',
    element: <AddressGrid />
  },
  {
    path: '/address/add',
    element: <AddressAdd />
  },
  {
    path: '/address/edit/:id',
    element: <AddressEdit />
  },
  {
    path: '/address/delete/:id',
    element: <AddressDelete />
  }
  ];
export default AppRoutes;