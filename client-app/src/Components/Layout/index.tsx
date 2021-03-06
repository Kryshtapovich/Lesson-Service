import { AddCircle, Group, List as ListIcon } from "@mui/icons-material";
import { ListItem, ListItemIcon, ListItemText } from "@mui/material";
import Box from "@mui/material/Box";
import Drawer from "@mui/material/Drawer";
import List from "@mui/material/List";
import { NavLink, useLocation } from "react-router-dom";

import { content, drawer, globalWrapper, listItem, navLink } from "./style";

const routes = [
  { to: "/", icon: <ListIcon />, text: "All Surveys" },
  { to: "/survey-creation", icon: <AddCircle />, text: "Survey Creation" },
  { to: "/students", icon: <Group />, text: "Students" }
];

export default function Layout(props: React.PropsWithChildren<{}>) {
  const { pathname } = useLocation();

  return (
    <Box sx={globalWrapper}>
      <Drawer PaperProps={{ sx: drawer }} variant="permanent" anchor="left">
        <List>
          {routes.map((route) => (
            <NavLink to={route.to} style={navLink} key={route.to}>
              <ListItem button sx={listItem(pathname === route.to)}>
                <ListItemIcon>{route.icon}</ListItemIcon>
                <ListItemText>{route.text}</ListItemText>
              </ListItem>
            </NavLink>
          ))}
        </List>
      </Drawer>
      <Box sx={content}>{props.children}</Box>
    </Box>
  );
}
