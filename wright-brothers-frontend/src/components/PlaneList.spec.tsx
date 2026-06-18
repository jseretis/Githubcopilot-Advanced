import { test, expect } from '@playwright/experimental-ct-react';
import PlaneList from './PlaneList';
import type { HooksConfig } from '../../playwright';

test('should render the list of planes', async ({ mount }) => {
  const planes = [
    { id: 1, name: "Wright Flyer", year: 1903 },
    { id: 2, name: "Wright Model A", year: 1905 },
    { id: 3, name: "Wright Model B", year: 1910 },
  ];

  const component = await mount<HooksConfig>(<PlaneList planes={planes} />, {
    hooksConfig: { routing: true },
  });

  await expect(component).toContainText('Wright Flyer');
  await expect(component).toContainText('Wright Model A');
  await expect(component).toContainText('Wright Model B');
});