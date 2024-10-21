import React from 'react';
import {
  CDBSidebar,
  CDBSidebarContent,
  CDBSidebarHeader,
  CDBSidebarMenu,
  CDBSidebarMenuItem,
  CDBSidebarFooter,
} from 'cdbreact';
import { Link } from 'react-router-dom';

export const Sidebar = () => {
  return (
      <CDBSidebar>
        <CDBSidebarHeader prefix={<i className="fa fa-bars" />}></CDBSidebarHeader>
        <CDBSidebarContent>
          <CDBSidebarMenu>
            <CDBSidebarMenuItem icon="th-large">
              <Link to="/admin/dashboard">Dashboard</Link>
            </CDBSidebarMenuItem>
            <CDBSidebarMenuItem icon="sticky-note">
              <Link to="/admin/account">Account</Link>
            </CDBSidebarMenuItem>
            <CDBSidebarMenuItem icon="credit-card" iconType="solid">
              <Link to="/admin/news">News</Link>
            </CDBSidebarMenuItem>
          </CDBSidebarMenu>
        </CDBSidebarContent>
        <CDBSidebarFooter style={{ textAlign: 'center' }}>

        </CDBSidebarFooter>
      </CDBSidebar>
  );
};

export default Sidebar;
